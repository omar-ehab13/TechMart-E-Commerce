using TechMart.Domain.Entities;

namespace TechMart.Domain.Interfaces;

public interface IInventoryRepository : IRepository<Inventory>
{
    Task<Inventory?> GetByProductIdAsync(int productId, CancellationToken cancellationToken = default);
    Task<IReadOnlyList<Inventory>> GetLowStockAsync(int threshold, CancellationToken cancellationToken = default);
}
