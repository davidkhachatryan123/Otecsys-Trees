using Microsoft.EntityFrameworkCore;
using SQL.ClosureTable.Models;

namespace SQL.ClosureTable.Database;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
  public DbSet<Organization> Organizations { get; set; }
  public DbSet<OrganizationClosure> OrganizationClosures { get; set; }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder.Entity<OrganizationClosure>()
      .HasKey(o => new { o.NodeId, o.ParentId });

    modelBuilder.Entity<OrganizationClosure>()
      .HasOne(c => c.Node)
      .WithMany()
      .OnDelete(DeleteBehavior.NoAction);

    modelBuilder.Entity<OrganizationClosure>()
      .HasOne(c => c.Parent)
      .WithMany()
      .OnDelete(DeleteBehavior.NoAction);

    modelBuilder.Entity<Organization>()
      .HasData(new Organization() { Id = 1, Name = "root" });
  }
}
