﻿using SQL.PathBased.Models;
using SQL.PathBased.Services.Repositories;

namespace SQL.PathBased.Services.OrganizationsComposite;

public class CompositeOrganization(IOrganizationRepository organizationRepository) : OrganizationExtension
{
  private readonly IOrganizationRepository _organizationRepository = organizationRepository;

  private readonly List<Organization> _organizations = [];

  public override async Task<CompositeOrganization> AddAsync(Organization org)
  {
    org.ParentId = Id ?? -1;
    org.Path = Id is not null ? $"{Path}/{Id}" : "";

    await _organizationRepository.CreateAsync(org);

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
