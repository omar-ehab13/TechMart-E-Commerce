using TechMart.Domain.Entities.Base;

namespace TechMart.Domain.Entities;

public class OrderItem : BaseEntity
{
    public int OrderId { get; set; }
    public int ProductId { get; set; }

    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }

    public string ProductName { get; set; } = string.Empty; // snapshot
    public string SKU { get; set; } = string.Empty; // snapshot

    public decimal Subtotal => UnitPrice * Quantity;

    public Order? Order { get; set; }
    public Product? Product { get; set; }
}