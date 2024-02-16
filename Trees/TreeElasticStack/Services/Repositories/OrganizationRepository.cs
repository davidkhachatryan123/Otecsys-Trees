using Nest;

namespace TreeElasticStack.Services.Repositories;

public class OrganizationRepository(ElasticClient client) : IOrganizationRepository
{
  private readonly ElasticClient _client = client;

  public async Task<GetResponse<Organization>> GetIndexAsync(string orgId)
    => await _client.GetAsync<Organization>(orgId);

  public async Task<IndexResponse> IndexAsync(Organization org)
    => await _client.IndexAsync(org, c => c.Id(new Id(org.Id)));

  public async Task<DeleteResponse> DeleteIndexAsync(string orgId)
    => await _client.DeleteAsync<Organization>(orgId);
}
