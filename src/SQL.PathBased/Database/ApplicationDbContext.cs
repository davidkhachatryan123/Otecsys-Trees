using Microsoft.EntityFrameworkCore;
using SQL.PathBased.Models;

namespace SQL.PathBased.Database;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
  public DbSet<Organization> Organizations { get; set; }
}
