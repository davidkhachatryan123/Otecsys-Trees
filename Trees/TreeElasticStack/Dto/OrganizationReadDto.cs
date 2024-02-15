namespace TreeElasticStack;

public class OrganizationReadDto
{
  public int Id { get; set; }
  public string CompanyName { get; set; } = null!;
  public int ParentId { get; set; }
}
