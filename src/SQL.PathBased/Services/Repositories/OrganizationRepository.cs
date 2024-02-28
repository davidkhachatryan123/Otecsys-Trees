using Microsoft.EntityFrameworkCore;
using TreeSQL.Database;
using TreeSQL.Models;

namespace TreeSQL.Services.Repositories;

public class OrganizationRepository(ApplicationDbContext context) : IOrganizationRepository
{
  private readonly ApplicationDbContext _context = context;

  public async Task<IReadOnlyCollection<Organization>> GetAllAsync()
    => await _context.Organizations.ToArrayAsync();

  public async Task<Organization?> GetAsync(int? orgId)
    => await _context.Organizations.FirstOrDefaultAsync(o => o.Id == orgId);

  public async Task<Organization?> CreateAsync(Organization org)
  {
    var tmpOrg = await _context.Organizations.FirstOrDefaultAsync(o => o.Name == org.Name);
    if (tmpOrg is not null) return null;

    await _context.Organizations.AddAsync(org);
    await context.SaveChangesAsync();
    return org;
  }

  public async Task DeleteAsync(int? orgId)
  {
    var org = await GetAsync(orgId);
    if (org is null) return;

    _context.Organizations.Remove(org);
    await context.SaveChangesAsync();
  }
}
