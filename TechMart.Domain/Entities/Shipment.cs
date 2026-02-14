using TechMart.Domain.Entities.Base;
using TechMart.Domain.Enums;

namespace TechMart.Domain.Entities;

public class Shipment : BaseEntity
{
    public int OrderId { get; set; }
    public ShippingCarrier Carrier { get; set; }
    public ShippingMethod ShippingMethod { get; set; }

    public string? TrackingNumber { get; set; }
    public decimal ShippingCost { get; set; }
    public decimal Weight { get; set; }

    public DateTime? ShipmentDate { get; set; }
    public DateTime? EstimatedDeliveryDate { get; set; }
    public DateTime? ActualDeliveryDate { get; set; }

    public ShipmentStatus ShipmentStatus { get; set; }

    public Order? Order { get; set; }
}