using Microsoft.Extensions.Configuration;

namespace Trees.Generator.Strategies;

public class TreeGenerator(List<TreeStrategy> strategies, IConfiguration configuration)
{
  public async Task GenerateTreesAsync()
  {
    if (strategies.Count == 0) return;

    var treeSettingsSection = configuration.GetSection("TreeSettings");
    int maxChildren = treeSettingsSection.GetValue<int>("Children:Max");
    int minChildren = treeSettingsSection.GetValue<int>("Children:Min");
    int maxDepth = treeSettingsSection.GetValue<int>("MaxDepth");
    int maxWidth = treeSettingsSection.GetValue<int>("MaxWidth");

    Random rnd = new();

    for (int depth = 0; depth < maxDepth; depth++)
    {
      Console.WriteLine($"Generating nodes for depth: {depth + 1}");

      int start = rnd.Next(1, maxWidth);
      int end = rnd.Next(start, maxWidth);

      strategies.ForEach(strategy => strategy.DecreaseNodesWidth(maxWidth, start, end));

      for (int previous_depth_node_i = 0; previous_depth_node_i < strategies[0].PreviousNodesCount; previous_depth_node_i++)
      {
        for (int children = 0; children < rnd.Next(minChildren, maxChildren + 1); children++)
        {
          string org_name = Shared.RandomString(30, rnd);

          foreach (var strategy in strategies)
            await strategy.StoreAsync(org_name, previous_depth_node_i);
        }
      }
    }
  }
}