using TreeSQL.Models;

namespace TreeSQL.Services.OrganizationsComposite;

public abstract class OrganizationExtension : Organization
{
  public abstract Task AddAsync(Organization org);
  public abstract Task RemoveAsync(Organization org);
}
