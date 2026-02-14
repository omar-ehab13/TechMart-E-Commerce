using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TechMart.Domain.Entities;

namespace TechMart.Infrastructure.Configurations;

public class WishlistConfiguration : IEntityTypeConfiguration<Wishlist>
{
    public void Configure(EntityTypeBuilder<Wishlist> builder)
    {
        builder.ToTable("Wishlists");
        builder.HasKey(w => w.Id);

        builder.Property(w => w.CustomerId).HasMaxLength(450).IsRequired();
        builder.Property(w => w.CreatedBy).HasMaxLength(450);

        builder.HasMany(w => w.Items)
            .WithOne(i => i.Wishlist)
            .HasForeignKey(i => i.WishlistId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasIndex(w => w.CustomerId).IsUnique();
    }
}
