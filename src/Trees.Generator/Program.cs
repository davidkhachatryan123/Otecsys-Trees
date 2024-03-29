﻿using Common.Interfaces;
using Elasticsearch.Net;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using Nest;
using Trees.Generator.Strategies;

// Read and build configuration
var builder = new ConfigurationBuilder()
  .SetBasePath(Directory.GetCurrentDirectory())
  .AddJsonFile("config.json", optional: false);
var config = builder.Build();

// Create client for MongoDB
var mongo_client = new MongoClient(config.GetConnectionString("MongoOrganizationDb"));
BsonClassMap.RegisterClassMap<MongoDB.Models.Organization>(classMap =>
{
  classMap.AutoMap();
});

// Create client for ElasticSearch
var es_connectionPool = new SingleNodeConnectionPool(new Uri(config.GetConnectionString("ElasticSearchUrl")!));
var es_connectionSettings = new ConnectionSettings(es_connectionPool)
  .DefaultIndex("organizations_tree")
  .EnableApiVersioningHeader()
  .DisableDirectStreaming();
var es_client = new ElasticClient(es_connectionSettings);

// Create context of Closure Table Based database
var closureTable_optionsBuilder = new DbContextOptionsBuilder<SQL.ClosureTable.Database.ApplicationDbContext>()
  .UseSqlServer(config.GetConnectionString("ClosureTableOrganizationDb"));
var closureTable_context = new SQL.ClosureTable.Database.ApplicationDbContext(closureTable_optionsBuilder.Options);

// Create context of Path Based database
var pathBased_optionsBuilder = new DbContextOptionsBuilder<SQL.PathBased.Database.ApplicationDbContext>()
  .UseSqlServer(config.GetConnectionString("PathBasedOrganizationDb"));
var pathBased_context = new SQL.PathBased.Database.ApplicationDbContext(pathBased_optionsBuilder.Options);

// Create composite for MongoDB based
MongoDB.Services.Repositories.IOrganizationRepository mongo_orgRepo = new MongoDB.Services.Repositories.OrganizationRepository(mongo_client);
MongoDB.Services.OrganizationsComposite.CompositeOrganization mongo_composite = new(mongo_orgRepo);

// Create composite for ElasticSearch
ElasticStack.Services.Repositories.IOrganizationRepository es_orgRepo = new ElasticStack.Services.Repositories.OrganizationRepository(es_client);
ElasticStack.Services.OrganizationsComposite.CompositeOrganization es_composite = new(es_orgRepo);

// Create composite for Closure Table Based
IOrganizationRepository<SQL.ClosureTable.Models.Organization> sql_qt_orgRepo = new SQL.ClosureTable.Services.Repositories.OrganizationRepository(closureTable_context);
SQL.ClosureTable.Services.Repositories.IOrganizationClosureRepsotory sql_qt_orgClosureRepo = new SQL.ClosureTable.Services.Repositories.OrganizationClosureRepsotory(closureTable_context);
SQL.ClosureTable.Services.OrganizationsComposite.CompositeOrganization sql_qt_composite = new(sql_qt_orgRepo, sql_qt_orgClosureRepo, closureTable_context);

// Create composite for Path Based
IOrganizationRepository<SQL.PathBased.Models.Organization> sql_path_orgRepo = new SQL.PathBased.Services.Repositories.OrganizationRepository(pathBased_context);
SQL.PathBased.Services.OrganizationsComposite.CompositeOrganization sql_path_composite = new(sql_path_orgRepo);

TreeGenerator generator = new([
  new MongoDBStrategy(
    await mongo_composite.PickAsync()
  ),
  new ElasticsearchStrategy(
    await es_composite.AddAsync(new ElasticStack.Models.Organization("root") { Id = "1" }, enableGuid: false)
  ),
  new ClosureTableStrategy(
    await sql_qt_composite.PickAsync()
  ),
  new PathBasedTableStrategy(
    await sql_path_composite.AddAsync(new SQL.PathBased.Models.Organization("root"))
  )
], config);

await generator.GenerateTreesAsync();
