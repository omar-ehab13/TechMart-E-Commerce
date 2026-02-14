using TechMart.Domain.Entities.Base;
using TechMart.Domain.Enums;

namespace TechMart.Domain.Entities;

public class Address : BaseEntity
{
    public string CustomerId { get; set; } = string.Empty;

    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string AddressLine1 { get; set; } = string.Empty;
    public string? AddressLine2 { get; set; }
    public string City { get; set; } = string.Empty;
    public string State { get; set; } = string.Empty;
    public string PostalCode { get; set; } = string.Empty;
    public string Country { get; set; } = string.Empty;

    public AddressType AddressType { get; set; }
    public bool IsDefault { get; set; }

    public ICollection<Order> ShippingOrders { get; set; } = new List<Order>();
    public ICollection<Order> BillingOrders { get; set; } = new List<Order>();
}