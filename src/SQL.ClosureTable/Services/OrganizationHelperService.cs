using Common.Interfaces;
using SQL.ClosureTable.Services.Repositories;

namespace SQL.ClosureTable.Services;

public class OrganizationHelperService
  (IOrganizationClosureRepsotory organizationClosureRepsotory)
    : IOrganizationOperations<int>
{
  private readonly IOrganizationClosureRepsotory _organizationClosureRepsotory = organizationClosureRepsotory;

  public async Task<bool> CheckAccess(int nodeId, int parentId)
  => await _organizationClosureRepsotory.GetAsync(nodeId, parentId) is not null;
}
