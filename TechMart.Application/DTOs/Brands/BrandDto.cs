namespace TechMart.Application.DTOs.Brands;

public class BrandDto
{
    public int BrandId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string? LogoUrl { get; set; }
    public bool IsActive { get; set; }

    // Product count (for display purposes)
    public int ProductCount { get; set; }
}
