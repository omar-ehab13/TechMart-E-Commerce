using MediatR;
using TechMart.Application.DTOs.Products;
using TechMart.Application.Utilities;

namespace TechMart.Application.Queries.Products;

public class GetAllProductsQuery : IRequest<PagedResult<ProductListDto>>
{
    // Pagination
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 12;

    // Filtering
    public int? CategoryId { get; set; }
    public int? BrandId { get; set; }
    public string? SearchTerm { get; set; }
    public decimal? MinPrice { get; set; }
    public decimal? MaxPrice { get; set; }
    public bool? InStockOnly { get; set; }
    public bool? FeaturedOnly { get; set; }

    // Sorting
    public string SortBy { get; set; } = "Name"; // Name, Price, Newest, Featured
    public string SortOrder { get; set; } = "ASC"; // ASC, DESC
}

public class GetProductByIdQuery : IRequest<ProductDetailDto?>
{
    public int ProductId { get; set; }

    public GetProductByIdQuery(int productId)
    {
        ProductId = productId;
    }
}
