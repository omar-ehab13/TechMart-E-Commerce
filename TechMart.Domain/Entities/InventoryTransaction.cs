using TechMart.Domain.Entities.Base;
using TechMart.Domain.Enums;

namespace TechMart.Domain.Entities;

public class InventoryTransaction : BaseEntity
{
    public int InventoryId { get; set; }
    public InventoryTransactionType TransactionType { get; set; }
    public int Quantity { get; set; }
    public decimal? UnitCost { get; set; }
    public string? ReferenceNumber { get; set; }
    public string? Notes { get; set; }

    // Navigation property
    public virtual Inventory? Inventory { get; set; }
}