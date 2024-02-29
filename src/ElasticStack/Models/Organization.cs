using Nest;

namespace ElasticStack.Models;

[ElasticsearchType(RelationName = "organization")]
public class Organization
{
  [Text(Name = "id")]
  public string Id { get; set; } = null!;

  [Text(Name = "name")]
  public string Name { get; set; } = null!;

  [Text(Name = "parent_id")]
  public string? ParentId { get; set; }

  [Text(Name = "path")]
  public string Path { get; set; } = null!;

  public Organization() { }

  public Organization(string name)
    => this.Name = name;
}
