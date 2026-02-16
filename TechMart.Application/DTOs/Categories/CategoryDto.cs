namespace TechMart.Application.DTOs.Categories;

public class CategoryDto
{
    public int CategoryId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;

    // Parent category (for hierarchical structure)
    public int? ParentCategoryId { get; set; }
    public string? ParentCategoryName { get; set; }

    public int DisplayOrder { get; set; }
    public bool IsActive { get; set; }

    // Product count (for display purposes)
    public int ProductCount { get; set; }

    // Child categories (for tree view)
    public List<CategoryDto> SubCategories { get; set; } = new();
}
