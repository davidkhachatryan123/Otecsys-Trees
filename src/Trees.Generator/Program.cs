using Common.Interfaces;
using Elasticsearch.Net;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Nest;
using Trees.Generator;

// Read and build configuration
var builder = new ConfigurationBuilder()
      .SetBasePath(Directory.GetCurrentDirectory())
      .AddJsonFile("config.json", optional: false);
var config = builder.Build();

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

// Create composite for ElasticSearch
ElasticStack.Services.Repositories.IOrganizationRepository es_orgRepo = new ElasticStack.Services.Repositories.OrganizationRepository(es_client);
ElasticStack.Services.OrganizationsComposite.CompositeOrganization es_root = new(es_orgRepo);

// Create composite for Closure Table Based
IOrganizationRepository<SQL.ClosureTable.Models.Organization> sql_qt_orgRepo = new SQL.ClosureTable.Services.Repositories.OrganizationRepository(closureTable_context);
SQL.ClosureTable.Services.Repositories.IOrganizationClosureRepsotory sql_qt_orgClosureRepo = new SQL.ClosureTable.Services.Repositories.OrganizationClosureRepsotory(closureTable_context);
SQL.ClosureTable.Services.OrganizationsComposite.CompositeOrganization sql_qt_root = new(sql_qt_orgRepo, sql_qt_orgClosureRepo, closureTable_context);

// Create composite for Path Based
IOrganizationRepository<SQL.PathBased.Models.Organization> sql_path_orgRepo = new SQL.PathBased.Services.Repositories.OrganizationRepository(pathBased_context);
SQL.PathBased.Services.OrganizationsComposite.CompositeOrganization sql_path_root = new(sql_path_orgRepo);

await Generator.GenerateRandomDataAsync(config, es_root, sql_qt_root, sql_path_root);
