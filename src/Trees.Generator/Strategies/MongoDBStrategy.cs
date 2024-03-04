namespace Trees.Generator.Strategies;

public class MongoDBStrategy
  (SQL.PathBased.Services.OrganizationsComposite.CompositeOrganization composite)
  : TreeStrategy(composite)
{
  public override async Task StoreAsync(string name, int parnetId)
  {
    var current_node = await
    (
      (SQL.PathBased.Services.OrganizationsComposite.CompositeOrganization)
      _previous_depth_nodes[parnetId]
    )
    .AddAsync(new SQL.PathBased.Models.Organization(name));

    _current_depth_nodes.Add(current_node);
  }
}