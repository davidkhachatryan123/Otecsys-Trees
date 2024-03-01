using Microsoft.Extensions.Configuration;

namespace Trees.Generator;

public static class Generator
{
  public static async Task GenerateRandomDataAsync(IConfiguration configuration,
    ElasticStack.Services.OrganizationsComposite.CompositeOrganization es_root,
    SQL.ClosureTable.Services.OrganizationsComposite.CompositeOrganization sql_qt_composite,
    SQL.PathBased.Services.OrganizationsComposite.CompositeOrganization sql_path_composite)
  {
    var treeSettingsSection = configuration.GetSection("TreeSettings");
    int maxChildren = treeSettingsSection.GetValue<int>("Children:Max");
    int minChildren = treeSettingsSection.GetValue<int>("Children:Min");
    int maxDepth = treeSettingsSection.GetValue<int>("MaxDepth");
    int maxWidth = treeSettingsSection.GetValue<int>("MaxWidth");

    int es_id = 1;

    Random rnd = new();

    List<ElasticStack.Services.OrganizationsComposite.CompositeOrganization> es_previous_depth_nodes = [];
    List<ElasticStack.Services.OrganizationsComposite.CompositeOrganization> es_current_depth_nodes = [es_root];

    var sql_qt_root = await sql_qt_composite.PickAsync();
    List<SQL.ClosureTable.Services.OrganizationsComposite.CompositeOrganization> sql_qt_previous_depth_nodes = [];
    List<SQL.ClosureTable.Services.OrganizationsComposite.CompositeOrganization> sql_qt_current_depth_nodes = [sql_qt_root];

    var sql_path_root = await sql_path_composite.AddAsync(new SQL.PathBased.Models.Organization("root"));
    List<SQL.PathBased.Services.OrganizationsComposite.CompositeOrganization> sql_path_previous_depth_nodes = [];
    List<SQL.PathBased.Services.OrganizationsComposite.CompositeOrganization> sql_path_current_depth_nodes = [sql_path_root];


    for (int depth = 0; depth < maxDepth; depth++)
    {
      Console.WriteLine($"Generating nodes for depth: {depth}");

      int start = rnd.Next(1, maxWidth);
      int end = rnd.Next(start, maxWidth);

      if (sql_path_previous_depth_nodes.Count > maxWidth)
      {
        es_previous_depth_nodes = es_current_depth_nodes.GetRange(start, end);
        sql_qt_previous_depth_nodes = sql_qt_current_depth_nodes.GetRange(start, end);
        sql_path_previous_depth_nodes = sql_path_current_depth_nodes.GetRange(start, end);
      }
      else
      {
        es_previous_depth_nodes = [.. es_current_depth_nodes];
        sql_qt_previous_depth_nodes = [.. sql_qt_current_depth_nodes];
        sql_path_previous_depth_nodes = [.. sql_path_current_depth_nodes];
      }

      es_current_depth_nodes = [];
      sql_qt_current_depth_nodes = [];
      sql_path_current_depth_nodes = [];

      for (int previous_depth_node_i = 0; previous_depth_node_i < sql_path_previous_depth_nodes.Count; previous_depth_node_i++)
      {
        for (int children = 0; children < rnd.Next(minChildren, maxChildren + 1); children++, es_id++)
        {
          string org_name = RandomString(30, rnd);

          // ElasticStack
          var es_current_node = await es_previous_depth_nodes[previous_depth_node_i]
          .AddAsync(new ElasticStack.Models.Organization
          {
            Id = es_id.ToString(),
            Name = org_name
          }, enableGuid: false);

          es_current_depth_nodes.Add(es_current_node);

          // Closure Table
          var sql_qt_current_node = await sql_qt_previous_depth_nodes[previous_depth_node_i]
          .AddAsync(new SQL.ClosureTable.Models.Organization(org_name));

          sql_qt_current_depth_nodes.Add(sql_qt_current_node);

          // Path Based
          var sql_path_current_node = await sql_path_previous_depth_nodes[previous_depth_node_i]
          .AddAsync(new SQL.PathBased.Models.Organization(org_name));

          sql_path_current_depth_nodes.Add(sql_path_current_node);
        }
      }
    }
  }

  private static string RandomString(int length, Random random)
  {
    const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

    return new string(Enumerable.Repeat(chars, length)
      .Select(s => s[random.Next(s.Length)]).ToArray());
  }
}
