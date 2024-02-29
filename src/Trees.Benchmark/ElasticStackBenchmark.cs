using BenchmarkDotNet.Attributes;
using Elasticsearch.Net;
using ElasticStack.Models;
using Microsoft.Extensions.Configuration;
using Nest;

namespace Trees.Benchmark;

[MemoryDiagnoser]
[KeepBenchmarkFiles]
public class ElasticStackTableBenchmark
{
  public static IEnumerable<object[]> Data()
  {
    yield return new object[] { "100", "1" };
    yield return new object[] { "100", "99" };
    yield return new object[] { "100", "50" };
    yield return new object[] { "2", "1" };
    yield return new object[] { "50", "51" };
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

  [Benchmark]
  [ArgumentsSource(nameof(Data))]
  public async Task<bool> HasAccessSearchQuery(string nodeId, string parentId)
  {
    var call = await _client.SearchAsync<Organization>(s => s
      .Size(0)
      .Query(q => q
        .Bool(b => b
          .Must(m => m
            .Match(m => m
              .Field(f => f.Id)
              .Query(nodeId)
            )
          )
          .Filter(f => f
            .QueryString(qs => qs
              .Query("*" + parentId.ToString() + "*")
            )
          )
        )
      )
    );

    return call.Total == 1;
  }
}
