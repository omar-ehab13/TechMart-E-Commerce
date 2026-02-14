using TechMart.Domain.Entities.Base;

namespace TechMart.Domain.Entities;

public class ShoppingCart : BaseEntity
{
    public string? CustomerId { get; set; }
    public string? SessionId { get; set; }

    public ICollection<ShoppingCartItem> CartItems { get; set; } = new List<ShoppingCartItem>();
}
