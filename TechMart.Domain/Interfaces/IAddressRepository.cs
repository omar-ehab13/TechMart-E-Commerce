using TechMart.Domain.Entities;
using TechMart.Domain.Enums;

namespace TechMart.Domain.Interfaces;

public interface IAddressRepository : IRepository<Address>
{
    Task<IReadOnlyList<Address>> GetByCustomerIdAsync(string customerId, CancellationToken cancellationToken = default);
    Task<Address?> GetDefaultByCustomerAndTypeAsync(string customerId, AddressType addressType, CancellationToken cancellationToken = default);
}
