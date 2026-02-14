using TechMart.Domain.Entities.Base;

namespace TechMart.Domain.Entities;

public class Wishlist : BaseEntity
{
    public string CustomerId { get; set; } = string.Empty;

    public ICollection<WishlistItem> Items { get; set; } = new List<WishlistItem>();
}
