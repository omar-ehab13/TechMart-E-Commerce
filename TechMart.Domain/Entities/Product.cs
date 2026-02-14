using TechMart.Domain.Entities.Base;

namespace TechMart.Domain.Entities;

public class Product : BaseEntity
{
    public string SKU { get; set; } = string.Empty; // Stock Keeping Unit
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public int CategoryId { get; set; }
    public int BrandId { get; set; }
    public decimal Price { get; set; }
    public decimal CostPrice { get; set; }
    public bool IsActive { get; set; } = true;
    public bool IsFeatured { get; set; }

    public Category? Category { get; set; }
    public Brand? Brand { get; set; }
    public Inventory? Inventory { get; set; }
    public ICollection<ProductImage> Images { get; set; } = new List<ProductImage>();
    public ICollection<ProductSpecification> Specifications { get; set; } = new List<ProductSpecification>();
    public ICollection<ShoppingCartItem> CartItems { get; set; } = new List<ShoppingCartItem>();
    public ICollection<ProductReview> Reviews { get; set; } = new List<ProductReview>();
    public ICollection<WishlistItem> WishlistItems { get; set; } = new List<WishlistItem>();
    public ICollection<PurchaseOrderItem> PurchaseOrderItems { get; set; } = new List<PurchaseOrderItem>();
}
