using TechMart.Domain.Entities.Base;

namespace TechMart.Domain.Entities;

public class ProductSpecification : BaseEntity
{
    public int ProductId { get; set; }
    public string Key { get; set; } = string.Empty;
    public string Value { get; set; } = string.Empty;

    // Navigation property
    public Product? Product { get; set; }
}