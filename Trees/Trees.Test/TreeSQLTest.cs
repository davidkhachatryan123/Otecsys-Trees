using System.Diagnostics;
using Microsoft.AspNetCore.Mvc.Testing;
using Trees.Test.Data;

namespace Trees.Test;

public class TreeSQLTest(WebApplicationFactory<TreeSQL.Program> factory)
    : IClassFixture<WebApplicationFactory<TreeSQL.Program>>
{
    private readonly WebApplicationFactory<TreeSQL.Program> _factory = factory;

    [Theory]
    [ClassData(typeof(TestDataSQL))]
    public async void IsChildOf(int parent_ID, int[] children_IDs)
    {
        // Arrange
        Stopwatch stopwatch = new();
        var client = _factory.CreateClient();

        foreach (int childID in children_IDs)
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
        Console.WriteLine($"| SQL | {time} ms |");
    }
}