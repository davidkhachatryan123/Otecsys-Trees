
namespace TreeElasticStack.Services;

public class CompositeOrganization(string name) : OrganizationExtension(name)
{
  private readonly List<Organization> _organizations = [];

  public override void Add(Organization org)
  {
    org.Id = Guid.NewGuid().ToString();
    org.ParentId = Id;
    org.Path = $"{Path}/{org.Id}";

    _organizations.Add(org);
  }

  public override void Remove(Organization org)
  {
    _organizations.Remove(org);
  }
}
