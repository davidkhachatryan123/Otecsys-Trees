using BenchmarkDotNet.Attributes;
using Microsoft.Extensions.Configuration;

namespace Trees.Benchmark;

[MemoryDiagnoser]
[KeepBenchmarkFiles]
public class ElasticStackAPIBenchmark
{
  public static IEnumerable<object[]> Data()
  {
    //                  Children ID      Parent ID
    //                            ^      ^
    //                            |      |
    yield return new object[] { "1673", "1" };
    yield return new object[] { "1673", "509" };
    yield return new object[] { "1673", "1021" };
    yield return new object[] { "1673", "1499" };
    yield return new object[] { "1673", "1649" };
    yield return new object[] { "2", "1" };
    yield return new object[] { "500", "1" };
    yield return new object[] { "1000", "1" };
    yield return new object[] { "1500", "1" };
    yield return new object[] { "1000", "509" };
    yield return new object[] { "1500", "1021" };
  }

  private readonly HttpClient _client = new();

  [GlobalSetup]
  public void Setup()
  {
    var builder = new ConfigurationBuilder()
      .SetBasePath(Directory.GetCurrentDirectory())
      .AddJsonFile("config.json", optional: false);

    var config = builder.Build();

    _client.BaseAddress = new Uri(config["API_URLS:ElasticsearchBased"]!);
  }

  [Benchmark]
  [ArgumentsSource(nameof(Data))]
  public async Task<bool> HasAccessAsync(string nodeId, string parentId)
  {
    HttpResponseMessage response =
      await _client.GetAsync($"api/tree/{nodeId}/checkAccess?parentId={parentId}");
    response.EnsureSuccessStatusCode();

    return await response.Content.ReadAsStringAsync() == "true";
  }
}
