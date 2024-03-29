﻿using SQL.PathBased.Models;

namespace SQL.PathBased.Services.OrganizationsComposite;

public abstract class OrganizationExtension : Organization
{
  public abstract Task<CompositeOrganization> AddAsync(Organization org);
  public abstract Task<CompositeOrganization> RemoveAsync(Organization org);
}
