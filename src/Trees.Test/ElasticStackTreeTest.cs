using Microsoft.AspNetCore.Mvc.Testing;
using Trees.Test.Data;

namespace Trees.Test;

public class ElasticStackTreeTest(WebApplicationFactory<ElasticStack.Program> factory)
  : IClassFixture<WebApplicationFactory<ElasticStack.Program>>
{
  private readonly WebApplicationFactory<ElasticStack.Program> _factory = factory;

  [Theory]
  [ClassData(typeof(TestDataElasticStack))]
  public async void CheckAccess(string parent_ID, string[] children_IDs)
  {
    // Arrange
    var client = _factory.CreateClient();

    foreach (string childID in children_IDs)
    {
      // Act
      var response = await client.GetAsync($"/api/tree/{childID}/checkAccess?parnetId={parent_ID}");

      // Assert
      response.EnsureSuccessStatusCode();
      string result = await response.Content.ReadAsStringAsync();
      Assert.Equal("true", result);
    }
  }
}
