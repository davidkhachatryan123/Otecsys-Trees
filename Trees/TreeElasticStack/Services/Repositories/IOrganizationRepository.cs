using Nest;

namespace TreeElasticStack.Services.Repositories;

public interface IOrganizationRepository
{
  Task<GetResponse<Organization>> GetIndexAsync(string orgId);
  Task<IndexResponse> IndexAsync(Organization org);
  Task<DeleteResponse> DeleteIndexAsync(string orgId);
}
