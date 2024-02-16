using TreeElasticStack.Services;
using TreeElasticStack.Services.Repositories;

namespace TreeElasticStack;


public class StorableOrganization(string name, IOrganizationRepository organizationRepository)
  : CompositeOrganization(name)
{
  private readonly IOrganizationRepository _organizationRepository = organizationRepository;

  public override async void Add(Organization org)
  {
    base.Add(org);

    await _organizationRepository.IndexAsync(org);
  }

  public override async void Remove(Organization org)
  {
    base.Remove(org);

    await _organizationRepository.DeleteIndexAsync(org.Id);
  }
}
