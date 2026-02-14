using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TechMart.Domain.Entities;

namespace TechMart.Infrastructure.Configurations;

public class ShoppingCartItemConfiguration : IEntityTypeConfiguration<ShoppingCartItem>
{
    public void Configure(EntityTypeBuilder<ShoppingCartItem> builder)
    {
        builder.ToTable("ShoppingCartItems");
        builder.HasKey(s => s.Id);

        builder.Property(s => s.UnitPrice).HasColumnType("decimal(18,2)");
        builder.Property(s => s.CreatedBy).HasMaxLength(450);

        builder.HasOne(s => s.Cart)
            .WithMany(c => c.CartItems)
            .HasForeignKey(s => s.CartId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(s => s.Product)
            .WithMany(p => p.CartItems)
            .HasForeignKey(s => s.ProductId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasIndex(s => new { s.CartId, s.ProductId }).IsUnique();
    }
}
