using Common.Interfaces;
using ElasticStack.Models;
using ElasticStack.Services.Repositories;

namespace ElasticStack.Services.OrganizationsComposite;

public class CompositeOrganization(IOrganizationRepository organizationRepository) : OrganizationExtension, IOrganizationComposite
{
  private readonly IOrganizationRepository _organizationRepository = organizationRepository;

  private readonly List<Organization> _organizations = [];

  public override async Task<CompositeOrganization> AddAsync(Organization org, bool enableGuid = true)
  {
    if (enableGuid)
      org.Id = Guid.NewGuid().ToString();
    org.ParentId = Id;
    org.Path = $"{Path}/{org.Id}";

    await _organizationRepository.IndexAsync(org);

    _organizations.Add(org);

    return new CompositeOrganization(_organizationRepository)
    {
      Id = org.Id,
      Name = org.Name,
      ParentId = org.ParentId,
      Path = org.Path
    };
  }

  public override Task<CompositeOrganization> RemoveAsync(Organization org)
    => throw new NotImplementedException();
}
