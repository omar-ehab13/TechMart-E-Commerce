using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TechMart.Domain.Entities;

namespace TechMart.Infrastructure.Configurations;

public class ShipmentConfiguration : IEntityTypeConfiguration<Shipment>
{
    public void Configure(EntityTypeBuilder<Shipment> builder)
    {
        builder.ToTable("Shipments");
        builder.HasKey(s => s.Id);

        builder.Property(s => s.TrackingNumber).HasMaxLength(200);
        builder.Property(s => s.ShippingCost).HasColumnType("decimal(18,2)");
        builder.Property(s => s.Weight).HasColumnType("decimal(18,2)");
        builder.Property(s => s.CreatedBy).HasMaxLength(450);

        builder.HasIndex(s => s.OrderId).IsUnique();
        builder.HasIndex(s => s.TrackingNumber).HasFilter("[TrackingNumber] IS NOT NULL");
        builder.HasIndex(s => s.ShipmentStatus);

        builder.HasOne(s => s.Order)
            .WithOne(o => o.Shipment)
            .HasForeignKey<Shipment>(s => s.OrderId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}