namespace Common.Interfaces;

public interface IOrganizationRepository<TOrganization>
{
  Task<IReadOnlyCollection<TOrganization>> GetAllAsync();
  Task<TOrganization?> GetAsync(int? orgId);
  Task<TOrganization?> CreateAsync(TOrganization org);
  Task DeleteAsync(int? orgId);
}
