namespace TechMart.Application.DTOs.Products;

public class ProductListDto
{
    public int ProductId { get; set; }
    public string SKU { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string ShortDescription { get; set; } = string.Empty;

    // Category and Brand
    public string CategoryName { get; set; } = string.Empty;
    public string? BrandName { get; set; }

    // Pricing
    public decimal Price { get; set; }
    public string DisplayPrice => $"${Price:N2}";

    // Stock status
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

    // Featured flag
    public bool IsFeatured { get; set; }

    // Primary image
    public string? PrimaryImageUrl { get; set; }

    // Rating (for future use)
    public decimal? AverageRating { get; set; }
    public int ReviewCount { get; set; }
}
