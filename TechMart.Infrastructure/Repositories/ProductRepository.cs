using Microsoft.EntityFrameworkCore;
using TechMart.Domain.Entities;
using TechMart.Domain.Interfaces;
using TechMart.Infrastructure.Data;

namespace TechMart.Infrastructure.Repositories;

public class ProductRepository : GenericRepository<Product>, IProductRepository
{
    public ProductRepository(TechMartDbContext context) : base(context)
    {
    }

    public async Task<Product?> GetBySkuAsync(string sku, CancellationToken cancellationToken = default)
    {
        return await Context.Products
            .AsNoTracking()
            .FirstOrDefaultAsync(p => p.SKU == sku, cancellationToken);
    }

    public async Task<IReadOnlyList<Product>> GetByCategoryIdAsync(int categoryId, int skip, int take, CancellationToken cancellationToken = default)
    {
        return await Context.Products
            .AsNoTracking()
            .Where(p => p.CategoryId == categoryId && p.IsActive)
            .OrderBy(p => p.Name)
            .Skip(skip)
            .Take(take)
            .Include(p => p.Category)
            .Include(p => p.Brand)
            .ToListAsync(cancellationToken);
    }

    public async Task<IReadOnlyList<Product>> GetFeaturedAsync(int count, CancellationToken cancellationToken = default)
    {
        return await Context.Products
            .AsNoTracking()
            .Where(p => p.IsFeatured && p.IsActive)
            .OrderBy(p => p.Name)
            .Take(count)
            .Include(p => p.Category)
            .Include(p => p.Brand)
            .ToListAsync(cancellationToken);
    }

    public async Task<IReadOnlyList<Product>> SearchAsync(string searchTerm, int? categoryId, int? brandId, int skip, int take, CancellationToken cancellationToken = default)
    {
        var query = Context.Products.AsNoTracking().Where(p => p.IsActive);

        if (!string.IsNullOrWhiteSpace(searchTerm))
        {
            var term = searchTerm.Trim().ToLower();
            query = query.Where(p =>
                p.Name.ToLower().Contains(term) ||
                p.SKU.ToLower().Contains(term) ||
                (p.Description != null && p.Description.ToLower().Contains(term)));
        }

        if (categoryId.HasValue)
            query = query.Where(p => p.CategoryId == categoryId.Value);

        if (brandId.HasValue)
            query = query.Where(p => p.BrandId == brandId.Value);

        return await query
            .OrderBy(p => p.Name)
            .Skip(skip)
            .Take(take)
            .Include(p => p.Category)
            .Include(p => p.Brand)
            .ToListAsync(cancellationToken);
    }
}
