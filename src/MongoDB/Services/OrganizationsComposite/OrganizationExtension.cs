using MongoDB.Models;

namespace MongoDB.Services.OrganizationsComposite;

public abstract class OrganizationExtension : Organization
{
  public abstract Task<CompositeOrganization> AddAsync(Organization org);
  public abstract Task<CompositeOrganization> RemoveAsync(Organization org);
  public abstract Task<CompositeOrganization> PickAsync();
  public abstract Task<CompositeOrganization> PickAsync(Organization org);
}
