using TechMart.Domain.Entities.Base;

namespace TechMart.Domain.Entities;

public class PurchaseOrderItem : BaseEntity
{
    public int PurchaseOrderId { get; set; }
    public int ProductId { get; set; }
    public int Quantity { get; set; }
    public decimal UnitCost { get; set; }
    public decimal Total => Quantity * UnitCost;

    public PurchaseOrder? PurchaseOrder { get; set; }
    public Product? Product { get; set; }
}
