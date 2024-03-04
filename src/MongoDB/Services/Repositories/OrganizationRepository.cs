using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Models;

namespace MongoDB.Services.Repositories;

public class OrganizationRepository(IMongoClient mongoClient) : IOrganizationRepository
{
  private readonly IMongoCollection<Organization> organizations = mongoClient
  .GetDatabase("organizationdb")
  .GetCollection<Organization>("organizations");

  public async Task<IReadOnlyCollection<Organization>> GetAllAsync()
  => await organizations.AsQueryable().ToListAsync();

  public async Task<Organization?> GetAsync(ObjectId orgId)
  => await organizations
    .Find(o => o.Id == orgId)
    .FirstOrDefaultAsync();

  public async Task CreateAsync(Organization org)
  => await organizations.InsertOneAsync(org);

  public async Task DeleteAsync(ObjectId orgId)
  => await organizations.DeleteOneAsync(o => o.Id == orgId);
}
