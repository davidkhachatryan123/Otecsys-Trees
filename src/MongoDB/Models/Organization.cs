using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoDB.Models;

public class Organization
{
  [BsonId]
  public ObjectId Id { get; set; } = ObjectId.GenerateNewId();

  public string Name { get; set; } = null!;

  public ObjectId ParentId { get; set; }

  public List<ObjectId> Ancestors { get; set; } = [];

  public Organization() { }

  public Organization(string name)
    => this.Name = name;
}
