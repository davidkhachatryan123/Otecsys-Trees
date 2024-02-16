using System.Diagnostics;
using Microsoft.AspNetCore.Mvc.Testing;
using Trees.Test.Data;

namespace Trees.Test;

public class TreeElasticStackTest(WebApplicationFactory<TreeElasticStack.Program> factory)
  : IClassFixture<WebApplicationFactory<TreeElasticStack.Program>>
{
  private readonly WebApplicationFactory<TreeElasticStack.Program> _factory = factory;

  [Theory]
  [ClassData(typeof(TestDataElasticStack))]
  public async void IsChildOf(string parent_ID, string[] children_IDs)
  {
    // Arrange
    Stopwatch stopwatch = new();
    var client = _factory.CreateClient();

    foreach (string childID in children_IDs)
    {
      // Act
      stopwatch.Start();
      var response = await client.GetAsync($"/api/Tree/{childID}/IsChildOf?parnetId={parent_ID}");
      stopwatch.Stop();

      // Assert
      response.EnsureSuccessStatusCode();
      string result = await response.Content.ReadAsStringAsync();
      Assert.Equal("true", result);
    }

    var time = (double)stopwatch.ElapsedMilliseconds;
    Console.ForegroundColor = ConsoleColor.Magenta;
    Console.WriteLine($"| ElasticStack | {time} ms |");
  }
}
