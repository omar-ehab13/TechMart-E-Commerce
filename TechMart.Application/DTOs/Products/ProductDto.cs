namespace TechMart.Application.DTOs.Products;

public class ProductDto
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

    // Status flags
    public bool IsActive { get; set; }
    public bool IsFeatured { get; set; }

    // Stock information (from Inventory)
    public int? QuantityAvailable { get; set; }
    public bool InStock => QuantityAvailable.HasValue && QuantityAvailable.Value > 0;

    // Audit fields
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public string? CreatedBy { get; set; }

    // Image (primary image URL)
    public string? PrimaryImageUrl { get; set; }

    // Computed properties
    public string DisplayPrice => $"${Price:N2}";
    public string StockStatus
    {
        get
        {
            if (!QuantityAvailable.HasValue) return "Unknown";
            if (QuantityAvailable.Value == 0) return "Out of Stock";
            if (QuantityAvailable.Value <= 5) return "Low Stock";
            return "In Stock";
        }
    }
}
