using MediatR;
using TechMart.Application.DTOs.Products;
using TechMart.Application.Utilities;

namespace TechMart.Application.Queries.Products;

public class GetProductsByCategoryQuery : IRequest<PagedResult<ProductListDto>>
{
    public int CategoryId { get; set; }
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 12;
    public string SortBy { get; set; } = "Name";
    public string SortOrder { get; set; } = "ASC";

    public GetProductsByCategoryQuery(int categoryId)
    {
        CategoryId = categoryId;
    }
}
