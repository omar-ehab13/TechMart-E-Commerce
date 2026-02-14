using TechMart.Domain.Entities;

namespace TechMart.Domain.Interfaces;

public interface ICartRepository
{
    Task<ShoppingCart?> GetByCustomerIdAsync(string customerId, CancellationToken cancellationToken = default);
    Task<ShoppingCart?> GetBySessionIdAsync(string sessionId, CancellationToken cancellationToken = default);
}
