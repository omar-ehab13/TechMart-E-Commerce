using TechMart.Application.DTOs.Products;
using TechMart.Application.Queries.Products;
using TechMart.Application.Utilities;

namespace TechMart.Application.Interfaces;

public interface IProductService
{
    Task<PagedResult<ProductListDto>> GetAllAsync(
        GetAllProductsQuery request,
        CancellationToken cancellationToken);

    Task<List<ProductListDto>> GetFeaturedAsync(
        int count,
        CancellationToken cancellationToken);

    Task<ProductDetailDto?> GetByIdAsync(
        int productId,
        CancellationToken cancellationToken);

    Task<ProductDto?> GetBySkuAsync(
        string sku,
        CancellationToken cancellationToken);

    Task<PagedResult<ProductListDto>> SearchAsync(
        SearchProductsQuery request,
        CancellationToken cancellationToken);
}
