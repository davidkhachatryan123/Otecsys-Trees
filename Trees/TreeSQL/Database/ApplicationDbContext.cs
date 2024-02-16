using Microsoft.EntityFrameworkCore;
using TreeSQL.Models;

namespace TreeSQL.Database;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
  public DbSet<Organization> Organizations { get; set; }
}
