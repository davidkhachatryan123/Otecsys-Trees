using Common.Interfaces;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Models;

namespace MongoDB.Services;

public class OrganizationHelperService(IMongoClient mongoClient)
  : IOrganizationOperations<string>
{
  private readonly IMongoCollection<Organization> _organizations = mongoClient
    .GetDatabase("organizationdb")
    .GetCollection<Organization>("organizations");

  public async Task<bool> CheckAccess(string nodeId, string parentId)
  {
    try
    {
      return (await _organizations.Find(org => org.Id == ObjectId.Parse(nodeId))
                                  .FirstOrDefaultAsync())
                                  .Ancestors.Any(a => a == ObjectId.Parse(parentId));
    }
    catch { return false; }
  }
}
