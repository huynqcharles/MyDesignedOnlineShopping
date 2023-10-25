using Microsoft.EntityFrameworkCore;
using Shared.Models;

namespace API.Data;

public class MyDbContext : DbContext
{
    public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
    {
        
    }
    
    public DbSet<Property> Properties { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<PropertyValue> PropertyValues { get; set; }
    public DbSet<Variant> Variants { get; set; }
    public DbSet<VariantPropertyValue> VariantPropertyValues { get; set; }
    public DbSet<ProductProperty> ProductProperties { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ProductProperty>()
            .HasKey(pp => new { pp.ProductId, pp.PropertyId });
        
        modelBuilder.Entity<VariantPropertyValue>()
            .HasKey(vp => new { vp.PropertyValueId, vp.VariantId });
    }
}