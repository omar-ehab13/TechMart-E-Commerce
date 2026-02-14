using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TechMart.Domain.Entities;

namespace TechMart.Infrastructure.Configurations;

public class OrderStatusHistoryConfiguration : IEntityTypeConfiguration<OrderStatusHistory>
{
    public void Configure(EntityTypeBuilder<OrderStatusHistory> builder)
    {
        builder.ToTable("OrderStatusHistories");
        builder.HasKey(o => o.Id);

        builder.Property(o => o.Notes).HasMaxLength(1000);
        builder.Property(o => o.CreatedBy).HasMaxLength(450);

        builder.HasOne(o => o.Order)
            .WithMany(or => or.StatusHistory)
            .HasForeignKey(o => o.OrderId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasIndex(o => o.OrderId);
        builder.HasIndex(o => o.CreatedAt);
    }
}
