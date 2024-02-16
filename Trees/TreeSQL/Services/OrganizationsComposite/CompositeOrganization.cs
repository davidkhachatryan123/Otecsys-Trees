using TreeSQL.Models;
using TreeSQL.Services.Repositories;

namespace TreeSQL.Services.OrganizationsComposite;

public class CompositeOrganization(IOrganizationRepository organizationRepository) : OrganizationExtension
{
  private readonly IOrganizationRepository _organizationRepository = organizationRepository;

  private readonly List<Organization> _organizations = [];

  public override async Task AddAsync(Organization org)
  {
    org.ParentId = Id ?? -1;
    org.Path = Id is not null ? $"{Path}/{Id}" : "";
    var result = await _organizationRepository.CreateAsync(org);

    _organizations.Add(org);
  }

  public override async Task RemoveAsync(Organization org)
  {
    await _organizationRepository.DeleteAsync(org.Id);
    _organizations.Remove(org);
  }
}
