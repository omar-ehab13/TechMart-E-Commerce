using Microsoft.AspNetCore.Http;

namespace TechMart.Application.DTOs.Products;

public class CreateProductDto
{
    public string SKU { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;

    public int CategoryId { get; set; }
    public int? BrandId { get; set; }

    public decimal Price { get; set; }
    public decimal? CostPrice { get; set; }

    public bool IsActive { get; set; } = true;
    public bool IsFeatured { get; set; } = false;

    // Initial stock quantity
    public int InitialStock { get; set; } = 0;
    public string? WarehouseLocation { get; set; }
    public int ReorderPoint { get; set; } = 10;
    public int ReorderQuantity { get; set; } = 50;

    // Image uploads
    public List<IFormFile>? ImageFiles { get; set; }

    // Specifications
    public List<CreateProductSpecificationDto>? Specifications { get; set; }
}
