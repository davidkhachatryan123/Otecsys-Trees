using BenchmarkDotNet.Attributes;
using Microsoft.Extensions.Configuration;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using MongoDB.Models;

namespace Trees.Benchmark;

[MemoryDiagnoser]
[KeepBenchmarkFiles]
public class MongoDBBenchmark
{
  public static IEnumerable<object[]> Data()
  {
    //                 Children ID                           Parent ID
    //                           ^                           ^
    //                           |                           |
    yield return new object[] { "65e60651e43c8f0e6db9ae9b", "65e60512e43c8f0e6db99e9f" };
    yield return new object[] { "65e60513e43c8f0e6db99ea3", "65e60512e43c8f0e6db99e9f" };
  }

  private IMongoCollection<Organization> _organizations = null!;

  [GlobalSetup]
  public void Setup()
  {
    var builder = new ConfigurationBuilder()
      .SetBasePath(Directory.GetCurrentDirectory())
      .AddJsonFile("config.json", optional: false);

    var config = builder.Build();

    var client = new MongoClient(config.GetConnectionString("MongoOrganizationDb"));

    BsonClassMap.RegisterClassMap<MongoDB.Models.Organization>(classMap =>
    {
      classMap.AutoMap();
    });

    _organizations = client
    .GetDatabase("organizationdb")
    .GetCollection<Organization>("organizations");
  }

  [Benchmark]
  [ArgumentsSource(nameof(Data))]
  public bool HasAccess(string nodeId, string parentId)
  => _organizations.Find(org => org.Id == ObjectId.Parse(nodeId))
                   .FirstOrDefault()
                   .Ancestors.Any(a => a == ObjectId.Parse(parentId));
}
