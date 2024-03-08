using BenchmarkDotNet.Attributes;
using Microsoft.Extensions.Configuration;

namespace Trees.Benchmark;

[MemoryDiagnoser]
[KeepBenchmarkFiles]
public class MongoDBAPIBenchmark
{
  public static IEnumerable<object[]> Data()
  {
    //                                        Children ID    Parent ID
    //                                                  ^    ^
    //                                                  |    |
    yield return new object[] { "65e9ff02fe645ecb3332580b", "000000000000000000000000" };
    yield return new object[] { "65e9ff02fe645ecb3332580b", "65e9febdfe645ecb33324ef3" };
    yield return new object[] { "65e9ff02fe645ecb3332580b", "65e9fed7fe645ecb333252f3" };
    yield return new object[] { "65e9ff02fe645ecb3332580b", "65e9fef4fe645ecb333256af" };
    yield return new object[] { "65e9ff02fe645ecb3332580b", "65e9ff00fe645ecb333257db" };
    yield return new object[] { "65e9feaafe645ecb33324afd", "000000000000000000000000" };
    yield return new object[] { "65e9febdfe645ecb33324ee1", "000000000000000000000000" };
    yield return new object[] { "65e9fed6fe645ecb333252c9", "000000000000000000000000" };
    yield return new object[] { "65e9fef4fe645ecb333256b1", "000000000000000000000000" };
    yield return new object[] { "65e9fed6fe645ecb333252c9", "65e9febdfe645ecb33324ef3" };
    yield return new object[] { "65e9fef4fe645ecb333256b1", "65e9fed7fe645ecb333252f3" };
  }

  private readonly HttpClient _client = new();

  [GlobalSetup]
  public void Setup()
  {
    var builder = new ConfigurationBuilder()
      .SetBasePath(Directory.GetCurrentDirectory())
      .AddJsonFile("config.json", optional: false);

    var config = builder.Build();

    _client.BaseAddress = new Uri(config["API_URLS:MongoDBBased"]!);
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
