using Microsoft.EntityFrameworkCore;
using TechMart.Domain.Entities;
using TechMart.Domain.Enums;
using TechMart.Domain.Interfaces;
using TechMart.Infrastructure.Data;

namespace TechMart.Infrastructure.Repositories;

public class AddressRepository : GenericRepository<Address>, IAddressRepository
{
    public AddressRepository(TechMartDbContext context) : base(context)
    {
    }

    public async Task<IReadOnlyList<Address>> GetByCustomerIdAsync(string customerId, CancellationToken cancellationToken = default)
    {
        return await Context.Addresses
            .AsNoTracking()
            .Where(a => a.CustomerId == customerId)
            .OrderByDescending(a => a.IsDefault)
            .ThenBy(a => a.Id)
            .ToListAsync(cancellationToken);
    }

    public async Task<Address?> GetDefaultByCustomerAndTypeAsync(string customerId, AddressType addressType, CancellationToken cancellationToken = default)
    {
        return await Context.Addresses
            .AsNoTracking()
            .FirstOrDefaultAsync(a =>
                a.CustomerId == customerId &&
                a.AddressType == addressType &&
                a.IsDefault, cancellationToken);
    }
}
