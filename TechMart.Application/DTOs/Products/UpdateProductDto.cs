using Microsoft.AspNetCore.Http;

namespace TechMart.Application.DTOs.Products;

public class UpdateProductDto
{
    public int ProductId { get; set; }
    public string SKU { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;

    public int CategoryId { get; set; }
    public int? BrandId { get; set; }

    public decimal Price { get; set; }
    public decimal? CostPrice { get; set; }

    public bool IsActive { get; set; }
    public bool IsFeatured { get; set; }

    // Image management
    public List<IFormFile>? NewImageFiles { get; set; }
    public List<int>? ImageIdsToDelete { get; set; }

    // Specifications
    public List<UpdateProductSpecificationDto>? Specifications { get; set; }
}
