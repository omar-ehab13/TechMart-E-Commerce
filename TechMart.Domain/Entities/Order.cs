using TechMart.Domain.Entities.Base;
using TechMart.Domain.Enums;

namespace TechMart.Domain.Entities;

public class Order : BaseEntity
{
    public string OrderNumber { get; set; } = string.Empty;
    public string CustomerId { get; set; } = string.Empty;
    public DateTime OrderDate { get; set; }
    public OrderStatus OrderStatus { get; set; }

    public decimal Subtotal { get; set; }
    public decimal Tax { get; set; }
    public decimal Shipping { get; set; }
    public decimal Total { get; set; }

    public int? ShippingAddressId { get; set; }
    public int? BillingAddressId { get; set; }
    public int? CouponId { get; set; }
    public string? Notes { get; set; }

    public Address? ShippingAddress { get; set; }
    public Address? BillingAddress { get; set; }
    public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    public ICollection<OrderStatusHistory> StatusHistory { get; set; } = new List<OrderStatusHistory>();
    public Payment? Payment { get; set; }
    public Shipment? Shipment { get; set; }
    public Coupon? Coupon { get; set; }
}