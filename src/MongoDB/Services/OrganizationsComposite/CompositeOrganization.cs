using Common.Interfaces;
using MongoDB.Bson;
using MongoDB.Models;
using MongoDB.Services.Repositories;

namespace MongoDB.Services.OrganizationsComposite;

public class CompositeOrganization(IOrganizationRepository organizationRepository)
  : OrganizationExtension, IOrganizationComposite
{
  private readonly IOrganizationRepository _organizationRepository = organizationRepository;

  private readonly List<Organization> _organizations = [];

  public override async Task<CompositeOrganization> AddAsync(Organization org)
  {
    org.ParentId = Id;
    org.Ancestors = new List<ObjectId>(Ancestors) { Id };

    await _organizationRepository.CreateAsync(org);

    return new CompositeOrganization(_organizationRepository)
    {
      Id = org.Id,
      Name = org.Name,
      ParentId = org.ParentId,
      Ancestors = org.Ancestors
    };
  }

  public override Task<CompositeOrganization> RemoveAsync(Organization org)
  => throw new NotImplementedException();

  public override async Task<CompositeOrganization> PickAsync()
  => await PickAsync(new Organization() { Id = new ObjectId("000000000000000000000000") });

  public override async Task<CompositeOrganization> PickAsync(Organization org)
  {
    var picked = await _organizationRepository.GetAsync(org.Id);

    if (picked is null)
      return new CompositeOrganization(_organizationRepository);
    else
      return new CompositeOrganization(_organizationRepository)
      {
        Id = picked.Id,
        Name = picked.Name,
        ParentId = picked.ParentId,
        Ancestors = picked.Ancestors
      };
  }
}
