using Microsoft.AspNetCore.Mvc.Testing;

namespace Trees.Test;

public class MongoDBTreeTest(WebApplicationFactory<MongoDB.Program> factory)
  : IClassFixture<WebApplicationFactory<MongoDB.Program>>
{
  private readonly WebApplicationFactory<MongoDB.Program> _factory = factory;

  public static IEnumerable<object[]> CustomData =>
    [
      //               Parent ID   Children IDs
      //                       ^   ^
      //                       |   |
      //                       |    _ _ _ _ 
      //                       |            |
      ["000000000000000000000000", new[] { "65e5e7f9c66422bee7742790", "65e5e7f9c66422bee7742798" }]
    ];

  [Theory]
  [MemberData(nameof(CustomData))]
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
