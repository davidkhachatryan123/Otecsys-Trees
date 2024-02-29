using BenchmarkDotNet.Attributes;
using Elasticsearch.Net;
using ElasticStack.Models;
using Microsoft.Extensions.Configuration;
using Nest;

namespace Trees.Benchmark;

[MemoryDiagnoser]
public class ElasticStackTableBenchmark
{
  public static IEnumerable<object[]> Data()
  {
    yield return new object[] { "b9cc3caa-6f46-4295-852d-1ccc55ab9fb3", "dccf3fa7-0552-46ba-978d-6af4d0c8540e" };
    yield return new object[] { "b9cc3caa-6f46-4295-852d-1ccc55ab9fb3", "502875f9-8320-425e-94e7-c0b8cd0ca627" };
    yield return new object[] { "dccf3fa7-0552-46ba-978d-6af4d0c8540e", "502875f9-8320-425e-94e7-c0b8cd0ca627" };
  }

  private ElasticClient _client = null!;

  [GlobalSetup]
  public void Setup()
  {
    var builder = new ConfigurationBuilder()
      .SetBasePath(Directory.GetCurrentDirectory())
      .AddJsonFile("config.json", optional: false);

    var config = builder.Build();

    var connectionPool = new SingleNodeConnectionPool(new Uri(config.GetConnectionString("ElasticSearchUrl")!));

    var connectionSettings = new ConnectionSettings(connectionPool)
      .DefaultIndex("organizations_tree")
      .EnableApiVersioningHeader()
      .DisableDirectStreaming();

    _client = new ElasticClient(connectionSettings);
  }

  [Benchmark]
  [ArgumentsSource(nameof(Data))]
  public async Task<bool> HasAccess(string nodeId, string parentId)
  {
    var call = await _client.GetAsync<Organization>(nodeId);
    return call.Source.Path.Contains(parentId);
  }
}
