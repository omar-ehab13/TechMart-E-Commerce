using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TechMart.Domain.Entities;

namespace TechMart.Infrastructure.Configurations;

public class ProductSpecificationConfiguration : IEntityTypeConfiguration<ProductSpecification>
{
    public void Configure(EntityTypeBuilder<ProductSpecification> builder)
    {
        builder.ToTable("ProductSpecifications");
        builder.HasKey(ps => ps.Id);

        builder.Property(ps => ps.Key)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(ps => ps.Value)
            .HasMaxLength(500)
            .IsRequired();

        builder.Property(ps => ps.CreatedBy).HasMaxLength(450);

        builder.HasIndex(ps => ps.ProductId);
        builder.HasIndex(ps => new { ps.ProductId, ps.Key }).IsUnique();

        builder.HasOne(ps => ps.Product)
            .WithMany(p => p.Specifications)
            .HasForeignKey(ps => ps.ProductId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}