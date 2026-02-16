namespace TechMart.Application.DTOs.Products;

public class ProductDetailDto
{
    public int ProductId { get; set; }
    public string SKU { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;

    // Category information
    public int CategoryId { get; set; }
    public string CategoryName { get; set; } = string.Empty;

    // Brand information
    public int? BrandId { get; set; }
    public string? BrandName { get; set; }

    // Pricing
    public decimal Price { get; set; }
    public decimal? CostPrice { get; set; }
    public string DisplayPrice => $"${Price:N2}";

    // Stock information
    public int? QuantityAvailable { get; set; }
    public string StockStatus
    {
        get
        {
            if (!QuantityAvailable.HasValue || QuantityAvailable.Value == 0)
                return "Out of Stock";
            if (QuantityAvailable.Value <= 5)
                return "Low Stock";
            return "In Stock";
        }
    }
    public bool InStock => QuantityAvailable.HasValue && QuantityAvailable.Value > 0;

    // Status flags
    public bool IsActive { get; set; }
    public bool IsFeatured { get; set; }

    // Images
    public List<ProductImageDto> Images { get; set; } = new();
    public string? PrimaryImageUrl => Images.FirstOrDefault(i => i.IsPrimary)?.ImageUrl
                                      ?? Images.FirstOrDefault()?.ImageUrl;

    // Specifications
    public List<ProductSpecificationDto> Specifications { get; set; } = new();

    // Reviews (for future implementation)
    public decimal? AverageRating { get; set; }
    public int ReviewCount { get; set; }

    // Audit information
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }

    // Related products (for future implementation)
    public List<ProductListDto> RelatedProducts { get; set; } = new();
}
