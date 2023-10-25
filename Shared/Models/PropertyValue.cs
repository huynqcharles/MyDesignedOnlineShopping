using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shared.Models;

public class PropertyValue
{
    [Key]
    [Column("property_value_id")]
    public int PropertyValueId { get; set; }

    [Column("value")]
    public string Value { get; set; }

    [Column("property_id")]
    public int PropertyId { get; set; }

    [ForeignKey("PropertyId")]
    public Property Property { get; set; }
}