using System.Collections;
using AutoMapper;
using Nest;
using TreeElasticStack.Services.Repositories;

namespace TreeElasticStack.Services;

public class OrganizationHelperService
  (IOrganizationRepository organizationRepository, ElasticClient elasticClient)
{
  private readonly IOrganizationRepository _organizationRepository = organizationRepository;
  private readonly ElasticClient _elasticClient = elasticClient;

  public async Task<IEnumerable<Organization>> GetAllAsync()
  {
    return (await _elasticClient.SearchAsync<Organization>(s => s
    .Query(q => q.MatchAll())))
    .Hits.Select(s => s.Source);
  }

  public async Task<bool> IsChildOfAsync(string id, string parentId)
  {
    var call = await _organizationRepository.GetIndexAsync(id);

    return call.Source.Path.Contains(parentId);
  }
}
