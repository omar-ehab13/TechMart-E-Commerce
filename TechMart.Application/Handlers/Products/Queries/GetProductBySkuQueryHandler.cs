using MediatR;
using Microsoft.EntityFrameworkCore;
using TechMart.Application.DTOs.Products;
using TechMart.Application.Interfaces;
using TechMart.Application.Queries.Products;
using TechMart.Domain.Interfaces;

namespace TechMart.Application.Handlers.Products.Queries;

public class GetProductBySkuQueryHandler : IRequestHandler<GetProductBySkuQuery, ProductDto?>
{
    private readonly IProductService _productService;

    public GetProductBySkuQueryHandler(IProductService productService)
    {
        this._productService = productService;
    }

    public async Task<ProductDto?> Handle(GetProductBySkuQuery request, CancellationToken cancellationToken)
    {
        return await _productService.GetBySkuAsync(request.SKU, cancellationToken);
    }
}
