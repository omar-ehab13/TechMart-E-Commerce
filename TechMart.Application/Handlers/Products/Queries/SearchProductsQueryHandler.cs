using MediatR;
using Microsoft.EntityFrameworkCore;
using TechMart.Application.DTOs.Products;
using TechMart.Application.Interfaces;
using TechMart.Application.Queries.Products;
using TechMart.Application.Utilities;
using TechMart.Domain.Interfaces;

namespace TechMart.Application.Handlers.Products.Queries;

public class SearchProductsQueryHandler : IRequestHandler<SearchProductsQuery, PagedResult<ProductListDto>>
{
    private readonly IProductService _productService;

    public SearchProductsQueryHandler(IProductService productService)
    {
        this._productService = productService;
    }

    public async Task<PagedResult<ProductListDto>> Handle(SearchProductsQuery request, CancellationToken cancellationToken)
    {
       return await _productService.SearchAsync(request, cancellationToken);
    }
}
