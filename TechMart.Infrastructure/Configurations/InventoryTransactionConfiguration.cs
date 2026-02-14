using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TechMart.Domain.Entities;

namespace TechMart.Infrastructure.Configurations;

public class InventoryTransactionConfiguration : IEntityTypeConfiguration<InventoryTransaction>
{
    public void Configure(EntityTypeBuilder<InventoryTransaction> builder)
    {
        builder.ToTable("InventoryTransactions");
        builder.HasKey(t => t.Id);

        builder.Property(t => t.ReferenceNumber).HasMaxLength(100);
        builder.Property(t => t.Notes).HasMaxLength(1000);
        builder.Property(t => t.CreatedBy).HasMaxLength(450);

        builder.HasIndex(t => t.InventoryId);
        builder.HasIndex(t => t.TransactionType);
        builder.HasIndex(t => t.CreatedAt);
        builder.HasIndex(t => new { t.InventoryId, t.CreatedAt });

        builder.HasOne(t => t.Inventory)
            .WithMany(i => i.Transactions)
            .HasForeignKey(t => t.InventoryId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}