using Common.Interfaces;
using SQL.ClosureTable.Database;
using SQL.ClosureTable.Models;
using SQL.ClosureTable.Services.Repositories;

namespace SQL.ClosureTable.Services.OrganizationsComposite;

public class CompositeOrganization
  (
    IOrganizationRepository<Organization> organizationRepository,
    IOrganizationClosureRepsotory organizationClosureRepsotory,
    ApplicationDbContext context
  ) : OrganizationExtension
{
  private readonly IOrganizationRepository<Organization> _organizationRepository = organizationRepository;
  private readonly IOrganizationClosureRepsotory _organizationClosureRepsotory = organizationClosureRepsotory;
  private readonly ApplicationDbContext _context = context;

  public override async Task<CompositeOrganization> AddAsync(Organization org)
  {
    var parentIds = await _organizationClosureRepsotory.GetParentIdsAsync(this);

    using var transaction = _context.Database.BeginTransaction();

    try
    {
      var newOrg = await _organizationRepository.CreateAsync(org)
        ?? throw new NullReferenceException("Organization wasn't created properly");

      await _organizationClosureRepsotory.CreateParentsAsync(newOrg.Id, [.. parentIds, Id]);

      await transaction.CommitAsync();
      return new CompositeOrganization(_organizationRepository, _organizationClosureRepsotory, _context)
      {
        Id = newOrg.Id,
        Name = newOrg.Name
      };
    }
    catch
    {
      await transaction.RollbackAsync();
      return this;
    }
  }

  public override Task<CompositeOrganization> RemoveAsync(Organization org)
    => throw new NotImplementedException();


  public override async Task<CompositeOrganization> PickAsync()
  {
    var picked = await _organizationRepository.GetAsync(1);

    return new CompositeOrganization(_organizationRepository, _organizationClosureRepsotory, _context)
    { Id = picked!.Id, Name = picked.Name };
  }

  public override async Task<CompositeOrganization> PickAsync(Organization org)
  {
    var picked = await _organizationRepository.GetAsync(org.Id);

    if (picked is null)
      return new CompositeOrganization(_organizationRepository, _organizationClosureRepsotory, _context);
    else
      return new CompositeOrganization(_organizationRepository, _organizationClosureRepsotory, _context)
      { Id = picked.Id, Name = picked.Name };
  }
}
