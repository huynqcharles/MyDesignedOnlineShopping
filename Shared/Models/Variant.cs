using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shared.Models;

public class Variant
{
    [Key]
    [Column("variant_id")]
    public int VariantId { get; set; }

    [Column("sku")]
    public string SKU { get; set; }

    [Column("price", TypeName = "decimal(18, 2)")]
    public decimal Price { get; set; }

    [Column("inventory")]
    public int Inventory { get; set; }

    [Column("product_id")]
    public int ProductId { get; set; }

    [ForeignKey("ProductId")]
    public Product Product { get; set; }
}