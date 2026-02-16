using MediatR;
using TechMart.Application.DTOs.Products;

namespace TechMart.Application.Queries.Products;

public class GetFeaturedProductsQuery : IRequest<List<ProductListDto>>
{
    public int Count { get; set; } = 8;

    public GetFeaturedProductsQuery(int count = 8)
    {
        Count = count;
    }
}
