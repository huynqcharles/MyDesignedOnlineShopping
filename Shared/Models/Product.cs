using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shared.Models;

public class Product
{
    [Key]
    [Column("product_id")]
    public int ProductId { get; set; }

    [Column("product_name")]
    public string ProductName { get; set; }

    [Column("description")]
    public string Description { get; set; }

    [Column("created_date")]
    public DateTime CreatedDate { get; set; }

    [Column("modified_date")]
    public DateTime ModifiedDate { get; set; }

    [Column("created_by")]
    public string CreatedBy { get; set; }

    [Column("modified_by")]
    public string ModifiedBy { get; set; }
}