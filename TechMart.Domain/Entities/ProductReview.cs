using TechMart.Domain.Entities.Base;

namespace TechMart.Domain.Entities;

public class ProductReview : BaseEntity
{
    public int ProductId { get; set; }
    public string CustomerId { get; set; } = string.Empty;
    public int Rating { get; set; } // 1-5
    public string? Title { get; set; }
    public string? Comment { get; set; }
    public bool IsApproved { get; set; }
    public bool IsVerifiedPurchase { get; set; }

    public Product? Product { get; set; }
}
