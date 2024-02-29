using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SQL.ClosureTable.Models;

public class Organization
{
  [Key]
  [Required]
  public int Id { get; set; }

  [Required]
  public string Name { get; set; } = null!;

  public Organization() { }

  public Organization(string name)
    => this.Name = name;
}
