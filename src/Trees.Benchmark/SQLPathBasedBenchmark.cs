using BenchmarkDotNet.Attributes;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SQL.PathBased.Database;

namespace Trees.Benchmark;

[MemoryDiagnoser]
[KeepBenchmarkFiles]
public class SQLPathBasedBenchmark
{
  public static IEnumerable<object[]> Data()
  {
    //                 Children ID   Parent ID
    //                           ^   ^
    //                           |   |
    yield return new object[] { 100, 1 };
    yield return new object[] { 100, 99 };
    yield return new object[] { 100, 50 };
    yield return new object[] { 2, 1 };
    yield return new object[] { 50, 51 };
  }

  private ApplicationDbContext _context = null!;

  [GlobalSetup]
  public void Setup()
  {
    var builder = new ConfigurationBuilder()
      .SetBasePath(Directory.GetCurrentDirectory())
      .AddJsonFile("config.json", optional: false);

    var config = builder.Build();

    var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>()
      .UseSqlServer(config.GetConnectionString("PathBasedOrganizationDb"));

    _context = new ApplicationDbContext(optionsBuilder.Options);
  }

  [Benchmark]
  [ArgumentsSource(nameof(Data))]
  public async Task<bool> HasAccess(int nodeId, int parentId)
  {
    var org = await _context.Organizations
                            .AsNoTracking()
                            .FirstOrDefaultAsync(o => o.Id == nodeId);

    return org is not null && org.Path.Contains(parentId.ToString());
  }

  [Benchmark]
  [ArgumentsSource(nameof(Data))]
  public async Task<bool> HasAccessOnlySQL(int nodeId, int parentId)
  {
    string? path = await _context.Organizations
                            .AsNoTracking()
                            .Where(o => o.Id == nodeId)
                            .Select(o => o.Path)
                            .FirstOrDefaultAsync();

    return path is not null && path.Contains(parentId.ToString());
  }
}
