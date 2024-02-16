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
    var client = _factory.CreateClient();

    foreach (string childID in children_IDs)
    {
      // Act
      var response = await client.GetAsync($"/api/Tree/{childID}/IsChildOf?parnetId={parent_ID}");

      // Assert
      response.EnsureSuccessStatusCode();
      string result = await response.Content.ReadAsStringAsync();
      Assert.Equal("true", result);
    }
  }
}
