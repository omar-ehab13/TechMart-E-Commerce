using MediatR;
using Microsoft.EntityFrameworkCore;
using TechMart.Application.DTOs.Products;
using TechMart.Application.Interfaces;
using TechMart.Application.Queries.Products;
using TechMart.Domain.Interfaces;

namespace TechMart.Application.Handlers.Products.Queries;

public class GetFeaturedProductsQueryHandler : IRequestHandler<GetFeaturedProductsQuery, List<ProductListDto>>
{
    private readonly IProductService _productService;

    public GetFeaturedProductsQueryHandler(IProductService productService)
    {
        this._productService = productService;
    }

    public async Task<List<ProductListDto>> Handle(GetFeaturedProductsQuery request, CancellationToken cancellationToken)
    {
        return await _productService.GetFeaturedAsync(request.Count, cancellationToken);
    }
}
