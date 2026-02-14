using TechMart.Domain.Entities.Base;
using TechMart.Domain.Enums;

namespace TechMart.Domain.Entities;

public class OrderStatusHistory : BaseEntity
{
    public int OrderId { get; set; }
    public OrderStatus Status { get; set; }
    public OrderStatus? PreviousStatus { get; set; }
    public string? Notes { get; set; }

    public Order? Order { get; set; }
}
