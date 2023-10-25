using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shared.Models;

public class Property
{
    [Key]
    [Column("property_id")]
    public int PropertyId { get; set; }

    [Column("property_name")]
    public string PropertyName { get; set; }
}