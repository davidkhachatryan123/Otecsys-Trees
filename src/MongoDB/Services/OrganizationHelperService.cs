using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Models;

namespace MongoDB.Services;

public class OrganizationHelperService(IMongoClient mongoClient)
{
  private readonly IMongoCollection<Organization> _organizations = mongoClient
    .GetDatabase("organizationdb")
    .GetCollection<Organization>("organizations");

  public bool CheckAccess(string nodeId, string parentId)
  {
    try
    {
      return _organizations.Find(org => org.Id == ObjectId.Parse(nodeId))
                         .FirstOrDefault()
                         .Ancestors.Any(a => a == ObjectId.Parse(parentId));
    }
    catch { return false; }
  }
}
