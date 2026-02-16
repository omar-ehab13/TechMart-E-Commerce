namespace TechMart.Application.DTOs.Products;

public class UpdateProductSpecificationDto
{
    public int? SpecId { get; set; } 
    public string SpecName { get; set; } = string.Empty;
    public string SpecValue { get; set; } = string.Empty;
    public bool IsDeleted { get; set; } 
}