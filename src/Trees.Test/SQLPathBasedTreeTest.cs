using Microsoft.AspNetCore.Mvc.Testing;

namespace Trees.Test;

public class SQLPathBasedTreeTest(WebApplicationFactory<SQL.PathBased.Program> factory)
    : IClassFixture<WebApplicationFactory<SQL.PathBased.Program>>
{
    private readonly WebApplicationFactory<SQL.PathBased.Program> _factory = factory;

    [Theory]
    [ClassData(typeof(Data))]
    public async void CheckAccess(int parent_ID, int[] children_IDs)
    {
        // Arrange
        var client = _factory.CreateClient();

        foreach (int childID in children_IDs)
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