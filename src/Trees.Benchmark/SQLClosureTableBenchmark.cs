using BenchmarkDotNet.Attributes;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SQL.ClosureTable.Database;

namespace Trees.Benchmark;

[MemoryDiagnoser]
[KeepBenchmarkFiles]
public class SQLClosureTableBenchmark
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
      .UseSqlServer(config.GetConnectionString("ClosureTableOrganizationDb"));

    _context = new ApplicationDbContext(optionsBuilder.Options);
  }

  [Benchmark]
  [ArgumentsSource(nameof(Data))]
  public async Task<bool> HasAccess(int nodeId, int parentId)
  => await _context.OrganizationClosures
                   .AsNoTracking()
                   .AnyAsync(o => o.NodeId == nodeId && o.ParentId == parentId);
}
