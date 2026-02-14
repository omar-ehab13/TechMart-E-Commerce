using TechMart.Domain.Entities.Base;

namespace TechMart.Domain.Entities;

public class WishlistItem : BaseEntity
{
    public int WishlistId { get; set; }
    public int ProductId { get; set; }
    public DateTime AddedAt { get; set; }

    public Wishlist? Wishlist { get; set; }
    public Product? Product { get; set; }
}
