using Nest;

namespace TreeElasticStack;

[ElasticsearchType(RelationName = "organization")]
public class Organization
{
  public int Id { get; set; }

  [Text(Name = "name")]
  public string Name { get; set; } = null!;

  [Text(Name = "parent_id")]
  public int ParentId { get; set; }

  [Text(Name = "path")]
  public string Path { get; set; } = null!;

  public Organization() { }

  public Organization(string name)
    => this.Name = name;
}
