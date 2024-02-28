namespace Common.Interfaces;

public interface IOrganizationOperations<TType>
{
  Task<bool> CheckAccess(TType nodeId, TType parentId);
}
