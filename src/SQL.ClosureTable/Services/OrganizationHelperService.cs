using Common.Interfaces;
using Microsoft.EntityFrameworkCore;
using SQL.ClosureTable.Database;

namespace SQL.ClosureTable.Services;

public class OrganizationHelperService(ApplicationDbContext context) : IOrganizationOperations<int>
{
  public async Task<bool> CheckAccess(int nodeId, int parentId)
  => await context.OrganizationClosures.AnyAsync(o => o.NodeId == nodeId && o.ParentId == parentId);
}
