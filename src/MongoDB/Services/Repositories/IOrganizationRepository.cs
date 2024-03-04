using MongoDB.Bson;
using MongoDB.Models;

namespace MongoDB.Services.Repositories;

public interface IOrganizationRepository
{
  Task<IReadOnlyCollection<Organization>> GetAllAsync();
  Task<Organization?> GetAsync(ObjectId orgId);
  Task CreateAsync(Organization org);
  Task DeleteAsync(ObjectId orgId);
}
