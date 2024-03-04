using BenchmarkDotNet.Attributes;
using Elasticsearch.Net;
using ElasticStack.Models;
using Microsoft.Extensions.Configuration;
using Nest;

namespace Trees.Benchmark;

[MemoryDiagnoser]
[KeepBenchmarkFiles]
public class ElasticStackBenchmark
{
  public static IEnumerable<object[]> Data()
  {
    //                  Children ID     Parent ID
    //                            ^     ^
    //                            |     |
    yield return new object[] { "100", "1" };
    yield return new object[] { "100", "99" };
    yield return new object[] { "100", "50" };
    yield return new object[] { "2", "1" };
    yield return new object[] { "50", "51" };
    // yield return new object[] { "1873", "1" };
    // yield return new object[] { "2", "1" };
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
  public bool HasAccess(string nodeId, string parentId)
  {
    var call = _client.Get<Organization>(nodeId);
    return call.Source.Path.Contains(parentId);
  }
}
