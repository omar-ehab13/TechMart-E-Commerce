using MediatR;
using Microsoft.EntityFrameworkCore;
using TechMart.Application.DTOs.Products;
using TechMart.Application.Interfaces;
using TechMart.Application.Queries.Products;
using TechMart.Domain.Interfaces;

namespace TechMart.Application.Handlers.Products.Queries;

public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, ProductDetailDto?>
{
    private readonly IProductService _productService;

    public GetProductByIdQueryHandler(IProductService productService)
    {
        this._productService = productService;
    }

    public async Task<ProductDetailDto?> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
    {
        return await _productService.GetByIdAsync(request.ProductId, cancellationToken);
    }
}
