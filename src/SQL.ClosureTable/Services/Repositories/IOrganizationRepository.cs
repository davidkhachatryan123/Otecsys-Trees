using SQL.ClosureTable.Models;

namespace SQL.ClosureTable.Services.Repositories;

public interface IOrganizationRepository
{
  Task<IReadOnlyCollection<Organization>> GetAllAsync();
  Task<Organization?> GetAsync(int? orgId);
  Task<Organization?> CreateAsync(Organization org);
  Task DeleteAsync(int? orgId);
}
