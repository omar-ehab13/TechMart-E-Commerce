using Microsoft.EntityFrameworkCore;
using TechMart.Domain.Entities;
using TechMart.Domain.Enums;
using TechMart.Domain.Interfaces;
using TechMart.Infrastructure.Data;

namespace TechMart.Infrastructure.Repositories;

public class OrderRepository : GenericRepository<Order>, IOrderRepository
{
    public OrderRepository(TechMartDbContext context) : base(context)
    {
    }

    public async Task<Order?> GetByOrderNumberAsync(string orderNumber, CancellationToken cancellationToken = default)
    {
        return await Context.Orders
            .Include(o => o.OrderItems)
            .Include(o => o.ShippingAddress)
            .Include(o => o.BillingAddress)
            .Include(o => o.Payment)
            .Include(o => o.Shipment)
            .FirstOrDefaultAsync(o => o.OrderNumber == orderNumber, cancellationToken);
    }

    public async Task<IReadOnlyList<Order>> GetByCustomerIdAsync(string customerId, int skip, int take, CancellationToken cancellationToken = default)
    {
        return await Context.Orders
            .AsNoTracking()
            .Where(o => o.CustomerId == customerId)
            .OrderByDescending(o => o.OrderDate)
            .Skip(skip)
            .Take(take)
            .Include(o => o.OrderItems)
            .ToListAsync(cancellationToken);
    }

    public async Task<IReadOnlyList<Order>> GetByStatusAsync(OrderStatus status, int skip, int take, CancellationToken cancellationToken = default)
    {
        return await Context.Orders
            .AsNoTracking()
            .Where(o => o.OrderStatus == status)
            .OrderBy(o => o.OrderDate)
            .Skip(skip)
            .Take(take)
            .Include(o => o.OrderItems)
            .ToListAsync(cancellationToken);
    }
}
