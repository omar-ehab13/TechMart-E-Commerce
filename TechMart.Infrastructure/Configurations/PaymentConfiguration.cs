using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TechMart.Domain.Entities;

namespace TechMart.Infrastructure.Configurations;

public class PaymentConfiguration : IEntityTypeConfiguration<Payment>
{
    public void Configure(EntityTypeBuilder<Payment> builder)
    {
        builder.ToTable("Payments");
        builder.HasKey(p => p.Id);

        builder.Property(p => p.Amount).HasColumnType("decimal(18,2)");

        builder.Property(p => p.TransactionId).HasMaxLength(200);
        builder.Property(p => p.PaymentGateway).HasMaxLength(100);
        builder.Property(p => p.AuthorizationCode).HasMaxLength(100);
        builder.Property(p => p.CreatedBy).HasMaxLength(450);

        builder.HasIndex(p => p.OrderId).IsUnique();
        builder.HasIndex(p => p.PaymentStatus);
        builder.HasIndex(p => p.TransactionId).HasFilter("[TransactionId] IS NOT NULL");

        builder.HasOne(p => p.Order)
            .WithOne(o => o.Payment)
            .HasForeignKey<Payment>(p => p.OrderId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}