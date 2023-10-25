using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shared.Models;

public class ProductProperty
{
    [Column("product_id")]
    public int ProductId { get; set; }

    [Column("property_id")]
    public int PropertyId { get; set; }

    [ForeignKey("ProductId")]
    public Product Product { get; set; }

    [ForeignKey("PropertyId")]
    public Property Property { get; set; }
}