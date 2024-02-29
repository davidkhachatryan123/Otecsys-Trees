using Microsoft.EntityFrameworkCore;
using SQL.ClosureTable.Database;
using SQL.ClosureTable.Models;

namespace SQL.ClosureTable.Services.Repositories;

public class OrganizationClosureRepsotory(ApplicationDbContext context) : IOrganizationClosureRepsotory
{
  private readonly ApplicationDbContext _context = context;

  public async Task<OrganizationClosure?> GetAsync(int nodeId, int parentId)
  => await _context.OrganizationClosures
    .FirstOrDefaultAsync(oc =>
      oc.NodeId == nodeId &&
      oc.ParentId == parentId);

  public async Task CreateParentsAsync(int nodeId, int[] parentIds)
  {
    await _context.AddRangeAsync(
      parentIds.Select(pId => new OrganizationClosure()
      {
        NodeId = nodeId,
        ParentId = pId
      })
    );

    await _context.SaveChangesAsync();
  }

  public async Task<IReadOnlyCollection<int>> GetParentIdsAsync(Organization org)
  => await _context.OrganizationClosures
    .Where(oc => oc.NodeId == org.Id)
    .Select(n => n.ParentId)
    .ToArrayAsync();
}
