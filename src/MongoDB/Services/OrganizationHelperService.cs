using Common.Interfaces;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Models;

namespace MongoDB.Services;

public class OrganizationHelperService(IMongoClient mongoClient)
  : IOrganizationOperations<string>
{
  private readonly IMongoCollection<Organization> organizations = mongoClient
    .GetDatabase("organizationdb")
    .GetCollection<Organization>("organizations");

  public async Task<bool> CheckAccess(string nodeId, string parentId)
  {
    var org = organizations.AsQueryable()
    .Where(o => o.Id == ObjectId.Parse(nodeId))
    .Where(o => o.Ancestors.Any(a => a == ObjectId.Parse(parentId)))
    .FirstOrDefault();

    return org is not null;
  }
}
