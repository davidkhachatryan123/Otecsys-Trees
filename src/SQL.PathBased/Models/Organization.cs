using System.ComponentModel.DataAnnotations;

namespace TreeSQL.Models;

public class Organization
{
  [Key]
  [Required]
  public int? Id { get; set; }

  [Required]
  public string Name { get; set; } = null!;

  public int? ParentId { get; set; }

  [Required]
  public string Path { get; set; } = null!;

  public Organization() { }

  public Organization(string name)
    => this.Name = name;
}
