namespace TechMart.Domain.Enums;

public enum ShipmentStatus
{
    Pending = 1,
    LabelCreated = 2,
    PickedUp = 3,
    InTransit = 4,
    OutForDelivery = 5,
    Delivered = 6,
    Exception = 7
}
