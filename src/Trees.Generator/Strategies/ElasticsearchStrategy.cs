
namespace Trees.Generator.Strategies;

public class ElasticsearchStrategy
  (ElasticStack.Services.OrganizationsComposite.CompositeOrganization composite)
  : TreeStrategy(composite)
{
  private int _autoIncrementedId = 0;
  private int AutoIncrementedId
  {
    get
    {
      return ++_autoIncrementedId;
    }
  }

  public override async Task StoreAsync(string name, int parnetId)
  {
    var current_node = await
    (
      (ElasticStack.Services.OrganizationsComposite.CompositeOrganization)
      _previous_depth_nodes[parnetId]
    )
    .AddAsync(new ElasticStack.Models.Organization
    {
      Id = AutoIncrementedId.ToString(),
      Name = name
    }, enableGuid: false);

    _current_depth_nodes.Add(current_node);
  }
}