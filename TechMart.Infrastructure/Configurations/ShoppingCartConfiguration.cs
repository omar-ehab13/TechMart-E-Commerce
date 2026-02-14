using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TechMart.Domain.Entities;

namespace TechMart.Infrastructure.Configurations;

public class ShoppingCartConfiguration : IEntityTypeConfiguration<ShoppingCart>
{
    public void Configure(EntityTypeBuilder<ShoppingCart> builder)
    {
        builder.ToTable("ShoppingCarts");
        builder.HasKey(c => c.Id);

        builder.Property(c => c.CustomerId).HasMaxLength(450);
        builder.Property(c => c.SessionId).HasMaxLength(200);
        builder.Property(c => c.CreatedBy).HasMaxLength(450);

        builder.HasMany(c => c.CartItems)
            .WithOne(i => i.Cart)
            .HasForeignKey(i => i.CartId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasIndex(c => c.SessionId).HasFilter("[SessionId] IS NOT NULL");
        builder.HasIndex(c => c.CustomerId).HasFilter("[CustomerId] IS NOT NULL");
    }
}