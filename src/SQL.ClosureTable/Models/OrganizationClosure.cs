using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SQL.ClosureTable.Models;

public class OrganizationClosure
{
  [Required]
  public int NodeId { get; set; }

  [Required]
  public int ParentId { get; set; }


  [JsonIgnore]
  public virtual Organization? Node { get; set; }

  [JsonIgnore]
  public virtual Organization? Parent { get; set; }
}
