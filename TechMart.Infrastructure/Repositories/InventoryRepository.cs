using Microsoft.EntityFrameworkCore;
using TechMart.Domain.Entities;
using TechMart.Domain.Interfaces;
using TechMart.Infrastructure.Data;

namespace TechMart.Infrastructure.Repositories;

public class InventoryRepository : GenericRepository<Inventory>, IInventoryRepository
{
    public InventoryRepository(TechMartDbContext context) : base(context)
    {
    }

    public async Task<Inventory?> GetByProductIdAsync(int productId, CancellationToken cancellationToken = default)
    {
        return await Context.Inventories
            .AsNoTracking()
            .FirstOrDefaultAsync(i => i.ProductId == productId, cancellationToken);
    }

    public async Task<IReadOnlyList<Inventory>> GetLowStockAsync(int threshold, CancellationToken cancellationToken = default)
    {
        return await Context.Inventories
            .AsNoTracking()
            .Where(i => i.QuantityOnHand <= threshold)
            .Include(i => i.Product)
            .OrderBy(i => i.QuantityOnHand)
            .ToListAsync(cancellationToken);
    }
}
