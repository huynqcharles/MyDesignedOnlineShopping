using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shared.Models;

public class VariantPropertyValue
{
    [Column("property_value_id")]
    public int PropertyValueId { get; set; }

    [Column("variant_id")]
    public int VariantId { get; set; }

    [ForeignKey("PropertyValueId")]
    public PropertyValue PropertyValue { get; set; }

    [ForeignKey("VariantId")]
    public Variant Variant { get; set; }
}