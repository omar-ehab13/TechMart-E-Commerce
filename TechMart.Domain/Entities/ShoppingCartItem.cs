using TechMart.Domain.Entities.Base;

namespace TechMart.Domain.Entities;

public class ShoppingCartItem : BaseEntity
{
    public int CartId { get; set; }
    public int ProductId { get; set; }
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    public DateTime AddedAt { get; set; }

    public ShoppingCart? Cart { get; set; }
    public Product? Product { get; set; }
}
