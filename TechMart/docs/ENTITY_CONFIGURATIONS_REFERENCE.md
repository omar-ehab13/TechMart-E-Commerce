# TechMart - Entity Configurations Reference

Quick reference for Entity Framework Core `IEntityTypeConfiguration<T>` implementations in `TechMart.Infrastructure/Configurations/`. Includes all delete constraints, indexes, and table configurations.

---

## Configuration Index

| Entity | Configuration Class | File |
|--------|---------------------|------|
| Product | ProductConfiguration | Configurations/ProductConfiguration.cs |
| Category | CategoryConfiguration | Configurations/CategoryConfiguration.cs |
| Brand | BrandConfiguration | Configurations/BrandConfiguration.cs |
| Order | OrderConfiguration | Configurations/OrderConfiguration.cs |
| OrderItem | OrderItemConfiguration | Configurations/OrderItemConfiguration.cs |
| Inventory | InventoryConfiguration | Configurations/InventoryConfiguration.cs |
| InventoryTransaction | InventoryTransactionConfiguration | Configurations/InventoryTransactionConfiguration.cs |
| Address | AddressConfiguration | Configurations/AddressConfiguration.cs |
| Payment | PaymentConfiguration | Configurations/PaymentConfiguration.cs |
| Shipment | ShipmentConfiguration | Configurations/ShipmentConfiguration.cs |
| ShoppingCart | ShoppingCartConfiguration | Configurations/ShoppingCartConfiguration.cs |
| ShoppingCartItem | ShoppingCartItemConfiguration | Configurations/ShoppingCartItemConfiguration.cs |
| ProductImage | ProductImageConfiguration | Configurations/ProductImageConfiguration.cs |
| ProductSpecification | ProductSpecificationConfiguration | Configurations/ProductSpecificationConfiguration.cs |

---

## Indexes Summary

| Table | Index | Type | Purpose |
|-------|-------|------|---------|
| Products | SKU | Unique | Product lookup |
| Products | CategoryId | Non-unique | Filter by category |
| Products | BrandId | Non-unique | Filter by brand |
| Products | IsActive | Non-unique | Active products |
| Products | IsFeatured | Non-unique | Featured products |
| Products | (CategoryId, IsActive) | Composite | Category + active filter |
| Categories | Name | Non-unique | Search |
| Categories | ParentCategoryId | Non-unique | Hierarchy |
| Categories | DisplayOrder | Non-unique | Sort order |
| Categories | IsActive | Non-unique | Active filter |
| Categories | (ParentCategoryId, DisplayOrder) | Composite | Hierarchical sort |
| Brands | Name | Unique | Brand lookup |
| Orders | OrderNumber | Unique | Order lookup |
| Orders | CustomerId | Non-unique | Customer orders |
| Orders | OrderDate | Non-unique | Date filtering |
| Orders | OrderStatus | Non-unique | Status filter |
| Orders | (CustomerId, OrderDate) | Composite | Customer history |
| Orders | (OrderStatus, OrderDate) | Composite | Status + date filter |
| OrderItems | OrderId | Non-unique | Order items lookup |
| OrderItems | ProductId | Non-unique | Product sales |
| Inventories | QuantityOnHand | Non-unique | Low stock queries |
| Addresses | (CustomerId, AddressType) | Composite | Customer addresses |
| Addresses | (CustomerId, IsDefault) | Filtered | Default address |
| Payments | OrderId | Unique | 1:1 with Order |
| Payments | PaymentStatus | Non-unique | Status filter |
| Payments | TransactionId | Filtered | Gateway lookup |
| Shipments | OrderId | Unique | 1:1 with Order |
| Shipments | TrackingNumber | Filtered | Tracking lookup |
| Shipments | ShipmentStatus | Non-unique | Status filter |
| InventoryTransactions | InventoryId | Non-unique | Transaction history |
| InventoryTransactions | TransactionType | Non-unique | Type filter |
| InventoryTransactions | CreatedAt | Non-unique | Date filtering |
| InventoryTransactions | (InventoryId, CreatedAt) | Composite | History by date |
| ProductImages | ProductId | Non-unique | Product images |
| ProductImages | (ProductId, DisplayOrder) | Composite | Image order |
| ProductSpecifications | ProductId | Non-unique | Product specs |
| ProductSpecifications | (ProductId, Key) | Unique | One spec per key per product |
| ShoppingCarts | SessionId | Filtered | Guest cart lookup |
| ShoppingCarts | CustomerId | Filtered | User cart lookup |
| ShoppingCartItems | (CartId, ProductId) | Unique | One item per product per cart |

---

## Delete Constraints (OnDelete Behavior)

| Parent | Child | Delete Behavior | Reason |
|--------|-------|-----------------|--------|
| Category | Product | Restrict | Prevent orphan products |
| Brand | Product | Restrict | Preserve referential integrity |
| Product | Inventory | Cascade | Inventory owned by product |
| Product | ProductImage | Cascade | Images owned by product |
| Product | ProductSpecification | Cascade | Specs owned by product |
| Product | ShoppingCartItem | Restrict | Preserve product record |
| Inventory | InventoryTransaction | Cascade | Transactions owned by inventory |
| Order | OrderItem | Cascade | Items owned by order |
| Order | Payment | Cascade | Payment owned by order |
| Order | Shipment | Cascade | Shipment owned by order |
| OrderItem | Product | Restrict | Preserve product record |
| Address | Order (Shipping) | Restrict | Preserve address history |
| Address | Order (Billing) | Restrict | Preserve address history |
| ShoppingCart | ShoppingCartItem | Cascade | Items owned by cart |

---

## Configuration Details by Entity

### ProductConfiguration

- **Table:** Products
- **Delete constraints:** Category Restrict, Brand Restrict, Inventory Cascade
- **Indexes:** SKU (unique), CategoryId, BrandId, IsActive, IsFeatured, (CategoryId, IsActive)

### CategoryConfiguration

- **Table:** Categories
- **Delete constraints:** ParentCategory Restrict (self-reference)
- **Indexes:** Name, ParentCategoryId, DisplayOrder, IsActive, (ParentCategoryId, DisplayOrder)

### BrandConfiguration

- **Table:** Brands
- **Indexes:** Name (unique)

### OrderConfiguration

- **Table:** Orders
- **Delete constraints:** Addresses Restrict, OrderItems Cascade, Payment Cascade, Shipment Cascade
- **Indexes:** OrderNumber (unique), CustomerId, OrderDate, OrderStatus, (CustomerId, OrderDate), (OrderStatus, OrderDate)

### OrderItemConfiguration

- **Table:** OrderItems
- **Delete constraints:** Order Cascade, Product Restrict
- **Indexes:** OrderId, ProductId

### InventoryConfiguration

- **Table:** Inventories
- **Delete constraints:** Product Cascade (1:1)
- **Indexes:** QuantityOnHand (low stock queries)

### InventoryTransactionConfiguration

- **Table:** InventoryTransactions
- **Delete constraints:** Inventory Cascade
- **Indexes:** InventoryId, TransactionType, CreatedAt, (InventoryId, CreatedAt)

### AddressConfiguration

- **Table:** Addresses
- **Indexes:** (CustomerId, AddressType), (CustomerId, IsDefault) filtered

### PaymentConfiguration

- **Table:** Payments
- **Delete constraints:** Order Cascade (1:1)
- **Indexes:** OrderId (unique), PaymentStatus, TransactionId filtered

### ShipmentConfiguration

- **Table:** Shipments
- **Delete constraints:** Order Cascade (1:1)
- **Indexes:** OrderId (unique), TrackingNumber filtered, ShipmentStatus

### ShoppingCartConfiguration

- **Table:** ShoppingCarts
- **Delete constraints:** CartItems Cascade
- **Indexes:** SessionId filtered, CustomerId filtered

### ShoppingCartItemConfiguration

- **Table:** ShoppingCartItems
- **Delete constraints:** Cart Cascade, Product Restrict
- **Indexes:** (CartId, ProductId) unique

### ProductImageConfiguration

- **Table:** ProductImages
- **Delete constraints:** Product Cascade
- **Indexes:** ProductId, (ProductId, DisplayOrder)

### ProductSpecificationConfiguration

- **Table:** ProductSpecifications
- **Delete constraints:** Product Cascade
- **Indexes:** ProductId, (ProductId, Key) unique

---

## Common Column Types

| Property Type | EF Configuration |
|---------------|------------------|
| decimal (money) | `HasColumnType("decimal(18,2)")` |
| string (short) | `HasMaxLength(64-100)` |
| string (medium) | `HasMaxLength(200-512)` |
| string (long) | `HasMaxLength(1000)` |
| Identity key | `HasMaxLength(450)` |

---

## Applying Configurations

Configurations are applied in `TechMartDbContext.OnModelCreating`:

```csharp
builder.ApplyConfigurationsFromAssembly(typeof(TechMartDbContext).Assembly);
```

All `IEntityTypeConfiguration<T>` classes in the Infrastructure assembly are discovered and applied automatically.
