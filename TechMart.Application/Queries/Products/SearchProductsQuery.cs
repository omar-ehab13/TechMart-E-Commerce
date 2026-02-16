using MediatR;
using TechMart.Application.DTOs.Products;
using TechMart.Application.Utilities;

namespace TechMart.Application.Queries.Products;

public class SearchProductsQuery : IRequest<PagedResult<ProductListDto>>
{
    public string SearchTerm { get; set; } = string.Empty;
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 12;
    public int? CategoryId { get; set; }
    public int? BrandId { get; set; }
    public decimal? MinPrice { get; set; }
    public decimal? MaxPrice { get; set; }
    public bool InStockOnly { get; set; } = false;
    public string SortBy { get; set; } = "Relevance";
    public string SortOrder { get; set; } = "DESC";
}
