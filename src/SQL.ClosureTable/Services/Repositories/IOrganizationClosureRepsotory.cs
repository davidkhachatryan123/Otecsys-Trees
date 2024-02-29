using SQL.ClosureTable.Models;

namespace SQL.ClosureTable.Services.Repositories;

public interface IOrganizationClosureRepsotory
{
  Task<OrganizationClosure?> GetAsync(int nodeId, int parentId);
  Task CreateParentsAsync(int nodeId, int[] parentIds);
  Task<IReadOnlyCollection<int>> GetParentIdsAsync(Organization org);
}
