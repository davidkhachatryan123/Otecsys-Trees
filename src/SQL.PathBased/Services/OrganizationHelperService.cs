using Common.Interfaces;
using SQL.PathBased.Models;
using SQL.PathBased.Services.Repositories;

namespace SQL.PathBased.Services;

public class OrganizationHelperService
  (IOrganizationRepository<Organization> organizationRepository)
    : IOrganizationOperations<int>
{
  private readonly IOrganizationRepository<Organization> _organizationRepository = organizationRepository;

  public async Task<bool> CheckAccess(int nodeId, int parentId)
  {
    var org = await _organizationRepository.GetAsync(nodeId);

    return org is not null && org.Path.Contains(parentId.ToString());
  }
}
