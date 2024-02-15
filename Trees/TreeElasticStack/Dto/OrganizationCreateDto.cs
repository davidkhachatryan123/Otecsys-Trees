namespace TreeElasticStack.Dto;

public class OrganizationCreateDto
{
  public string CompanyName { get; set; } = null!;
  public int ParentId { get; set; }
}
