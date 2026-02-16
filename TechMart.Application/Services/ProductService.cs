using Microsoft.EntityFrameworkCore;
using TechMart.Application.DTOs.Products;
using TechMart.Application.Interfaces;
using TechMart.Application.Queries.Products;
using TechMart.Application.Utilities;
using TechMart.Domain.Interfaces;

namespace TechMart.Application.Services;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;

    public ProductService(IProductRepository productRepository)
    {
        this._productRepository = productRepository;
    }

    public async Task<PagedResult<ProductListDto>> GetAllAsync(
       GetAllProductsQuery request,
       CancellationToken cancellationToken)
    {
        var query = _productRepository.GetAllQueryable()
            .Where(p => p.IsActive);

        // Filters
        if (request.CategoryId.HasValue)
            query = query.Where(p => p.CategoryId == request.CategoryId);

        if (request.BrandId.HasValue)
            query = query.Where(p => p.BrandId == request.BrandId);

        if (!string.IsNullOrWhiteSpace(request.SearchTerm))
        {
            query = query.Where(p =>
                EF.Functions.Like(p.Name, $"%{request.SearchTerm}%") ||
                EF.Functions.Like(p.Description, $"%{request.SearchTerm}%") ||
                EF.Functions.Like(p.SKU, $"%{request.SearchTerm}%"));
        }

        if (request.MinPrice.HasValue)
            query = query.Where(p => p.Price >= request.MinPrice);

        if (request.MaxPrice.HasValue)
            query = query.Where(p => p.Price <= request.MaxPrice);

        if (request.InStockOnly == true)
            query = query.Where(p => p.Inventory != null &&
                                     p.Inventory.QuantityAvailable > 0);

        if (request.FeaturedOnly == true)
            query = query.Where(p => p.IsFeatured);

        var totalCount = await query.CountAsync(cancellationToken);

        // Sorting
        query = ApplySorting(query, request.SortBy, request.SortOrder);

        // Pagination
        query = query
            .Skip((request.PageNumber - 1) * request.PageSize)
            .Take(request.PageSize);

        var products = await query
            .Include(p => p.Category)
            .Include(p => p.Brand)
            .Include(p => p.Inventory)
            .Include(p => p.Images.Where(i => i.IsPrimary))
            .Select(p => new ProductListDto
            {
                ProductId = p.Id,
                SKU = p.SKU,
                Name = p.Name,
                ShortDescription = p.Description.Length > 150
                    ? p.Description.Substring(0, 150) + "..."
                    : p.Description,
                CategoryName = p.Category.Name,
                BrandName = p.Brand!.Name,
                Price = p.Price,
                QuantityAvailable = p.Inventory!.QuantityAvailable,
                IsFeatured = p.IsFeatured,
                PrimaryImageUrl = p.Images
                    .Where(i => i.IsPrimary)
                    .Select(i => i.ImageUrl)
                    .FirstOrDefault()
            })
            .ToListAsync(cancellationToken);

        return new PagedResult<ProductListDto>
        {
            Items = products,
            TotalCount = totalCount,
            PageNumber = request.PageNumber,
            PageSize = request.PageSize
        };
    }

    public async Task<List<ProductListDto>> GetFeaturedAsync(
        int count,
        CancellationToken cancellationToken)
    {
        return await _productRepository
            .GetAllQueryable()
            .Where(p => p.IsActive && p.IsFeatured)
            .OrderByDescending(p => p.CreatedAt)
            .Take(count)
            .Select(p => new ProductListDto
            {
                ProductId = p.Id,
                SKU = p.SKU,
                Name = p.Name,
                ShortDescription = p.Description,
                CategoryName = p.Category.Name,
                BrandName = p.Brand!.Name,
                Price = p.Price,
                QuantityAvailable = p.Inventory!.QuantityAvailable,
                IsFeatured = p.IsFeatured,
                PrimaryImageUrl = p.Images
                    .Where(i => i.IsPrimary)
                    .Select(i => i.ImageUrl)
                    .FirstOrDefault()
            })
            .ToListAsync(cancellationToken);
    }

    public async Task<ProductDetailDto?> GetByIdAsync(
        int productId,
        CancellationToken cancellationToken)
    {
        var product = await _productRepository
            .GetAllQueryable()
            .Include(p => p.Category)
            .Include(p => p.Brand)
            .Include(p => p.Inventory)
            .Include(p => p.Images)
            .Include(p => p.Specifications)
            .FirstOrDefaultAsync(p => p.Id == productId, cancellationToken);

        if (product == null)
            return null;

        return new ProductDetailDto
        {
            ProductId = product.Id,
            SKU = product.SKU,
            Name = product.Name,
            Description = product.Description,
            CategoryName = product.Category.Name,
            BrandName = product.Brand?.Name,
            Price = product.Price,
            QuantityAvailable = product.Inventory?.QuantityAvailable
        };
    }

    public async Task<ProductDto?> GetBySkuAsync(
        string sku,
        CancellationToken cancellationToken)
    {
        return await _productRepository
            .GetAllQueryable()
            .Where(p => p.SKU == sku)
            .Select(p => new ProductDto
            {
                ProductId = p.Id,
                SKU = p.SKU,
                Name = p.Name,
                Price = p.Price
            })
            .FirstOrDefaultAsync(cancellationToken);
    }

    public async Task<PagedResult<ProductListDto>> SearchAsync(
        SearchProductsQuery request,
        CancellationToken cancellationToken)
    {
        return await GetAllAsync(
            new GetAllProductsQuery
            {
                SearchTerm = request.SearchTerm,
                PageNumber = request.PageNumber,
                PageSize = request.PageSize
            },
            cancellationToken);
    }

    private IQueryable<Domain.Entities.Product> ApplySorting(
        IQueryable<Domain.Entities.Product> query,
        string sortBy,
        string sortOrder)
    {
        var desc = sortOrder?.ToUpper() == "DESC";

        return sortBy?.ToLower() switch
        {
            "price" => desc ? query.OrderByDescending(p => p.Price)
                            : query.OrderBy(p => p.Price),
            "newest" => query.OrderByDescending(p => p.CreatedAt),
            _ => desc ? query.OrderByDescending(p => p.Name)
                      : query.OrderBy(p => p.Name)
        };
    }
}
