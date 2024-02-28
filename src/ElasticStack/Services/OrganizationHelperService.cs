using Nest;
using ElasticStack.Services.Repositories;
using Common.Interfaces;

namespace ElasticStack.Services;

public class OrganizationHelperService
  (IOrganizationRepository organizationRepository, ElasticClient elasticClient)
    : IOrganizationOperations<string>
{
  private readonly IOrganizationRepository _organizationRepository = organizationRepository;
  private readonly ElasticClient _elasticClient = elasticClient;

  public async Task<bool> CheckAccess(string nodeId, string parentId)
  {
    var call = await _organizationRepository.GetIndexAsync(nodeId);

    return call.Source.Path.Contains(parentId);
  }
}
