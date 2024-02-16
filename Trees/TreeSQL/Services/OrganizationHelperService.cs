using TreeSQL.Services.Repositories;

namespace TreeSQL.Services;

public class OrganizationHelperService(IOrganizationRepository organizationRepository)
{
  private readonly IOrganizationRepository _organizationRepository = organizationRepository;

  public async Task<bool> IsChildOfAsync(int id, int parentId)
  {
    var org = await _organizationRepository.GetAsync(id);

    return org is not null && org.Path.Contains(parentId.ToString());
  }
}
