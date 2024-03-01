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
    // yield return new object[] { 1873, 1 };
    // yield return new object[] { 2, 1 };
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
  public bool HasAccess(int nodeId, int parentId)
  {
    var org = _context.Organizations
                      .AsNoTracking()
                      .FirstOrDefault(o => o.Id == nodeId);

    return org is not null && org.Path.Contains(parentId.ToString());
  }
}
