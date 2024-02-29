using ElasticStack.Models;

namespace ElasticStack.Services.OrganizationsComposite;

public abstract class OrganizationExtension : Organization
{
  public abstract Task<CompositeOrganization> AddAsync(Organization org, bool enableGuid = true);
  public abstract Task<CompositeOrganization> RemoveAsync(Organization org);
}
