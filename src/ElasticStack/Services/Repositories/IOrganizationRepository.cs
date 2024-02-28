using Nest;

namespace ElasticStack.Services.Repositories;

public interface IOrganizationRepository
{
  Task<IEnumerable<Organization>> GetAllAsync();
  Task<GetResponse<Organization>> GetIndexAsync(string orgId);
  Task<IndexResponse> IndexAsync(Organization org);
  Task<DeleteResponse> DeleteIndexAsync(string orgId);
}
