namespace TreeElasticStack;

public abstract class OrganizationExtension(string name) : Organization(name)
{
  public abstract void Add(Organization org);
  public abstract void Remove(Organization org);
}
