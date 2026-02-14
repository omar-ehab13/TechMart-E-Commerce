using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TechMart.Domain.Entities;

namespace TechMart.Infrastructure.Configurations;

public class ProductReviewConfiguration : IEntityTypeConfiguration<ProductReview>
{
    public void Configure(EntityTypeBuilder<ProductReview> builder)
    {
        builder.ToTable("ProductReviews");
        builder.HasKey(p => p.Id);

        builder.Property(p => p.CustomerId).HasMaxLength(450).IsRequired();
        builder.Property(p => p.Title).HasMaxLength(200);
        builder.Property(p => p.Comment).HasMaxLength(2000);
        builder.Property(p => p.CreatedBy).HasMaxLength(450);

        builder.HasOne(p => p.Product)
            .WithMany(pr => pr.Reviews)
            .HasForeignKey(p => p.ProductId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasIndex(p => p.ProductId);
        builder.HasIndex(p => p.CustomerId);
        builder.HasIndex(p => p.IsApproved);
        builder.HasIndex(p => new { p.ProductId, p.IsApproved });
    }
}
