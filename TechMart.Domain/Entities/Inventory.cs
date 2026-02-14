using TechMart.Domain.Entities.Base;

namespace TechMart.Domain.Entities;

public class Inventory : BaseEntity
{
    public int ProductId { get; set; }
    public string WarehouseLocation { get; set; } = string.Empty;
    public int QuantityOnHand { get; set; }
    public int QuantityReserved { get; set; }
    public int QuantityAvailable => QuantityOnHand - QuantityReserved;
    public int ReorderPoint { get; set; }
    public int ReorderQuantity { get; set; }
    public DateTime? LastRestockDate { get; set; }

    // Navigation properties
    public virtual Product? Product { get; set; }
    public virtual ICollection<InventoryTransaction> Transactions { get; set; } = new List<InventoryTransaction>();
}
