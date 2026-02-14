using Microsoft.EntityFrameworkCore;
using TechMart.Domain.Entities;
using TechMart.Domain.Interfaces;
using TechMart.Infrastructure.Data;

namespace TechMart.Infrastructure.Repositories;

public class CartRepository : ICartRepository
{
    private readonly TechMartDbContext _context;

    public CartRepository(TechMartDbContext context)
    {
        _context = context;
    }

    public async Task<ShoppingCart?> GetByCustomerIdAsync(string customerId, CancellationToken cancellationToken = default)
    {
        return await _context.ShoppingCarts
            .Include(c => c.CartItems)
            .ThenInclude(i => i.Product)
            .FirstOrDefaultAsync(c => c.CustomerId == customerId, cancellationToken);
    }

    public async Task<ShoppingCart?> GetBySessionIdAsync(string sessionId, CancellationToken cancellationToken = default)
    {
        return await _context.ShoppingCarts
            .Include(c => c.CartItems)
            .ThenInclude(i => i.Product)
            .FirstOrDefaultAsync(c => c.SessionId == sessionId, cancellationToken);
    }
}
