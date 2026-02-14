# TechMart E-Commerce - Implementation Documentation

This document provides a comprehensive reference for the TechMart E-Commerce implementation, including the task list, domain entities, DbContext configuration, and Entity Framework configurations.

---

## Table of Contents

1. [Implementation Task List](#implementation-task-list)
2. [Domain Layer Overview](#domain-layer-overview)
3. [Enums](#enums)
4. [Value Objects](#value-objects)
5. [Core Entities](#core-entities)
6. [DbContext](#dbcontext)
7. [Entity Configurations](#entity-configurations)
8. [Project Structure](#project-structure)

---

## Implementation Task List

### PHASE 1: FOUNDATION & SETUP (Weeks 1-3)

| Task ID | Description | Status |
|---------|-------------|--------|
| 1.1 | Project Setup | ✅ Partial |
| 1.2 | Install NuGet Packages | ⏳ Pending |
| 1.3 | Database Setup | ✅ Partial |
| 1.4 | Create Domain Layer - Enums | ✅ Done |
| 1.5 | Create Domain Layer - Value Objects | ⏳ Pending |
| 1.6 | Create Domain Layer - Core Entities | ✅ Done |
| 1.7 | Create Domain Layer - Interfaces | ⏳ Pending |
| 1.8 | Create Infrastructure Layer - DbContext | ✅ Done |
| 1.9 | Create Infrastructure Layer - Repositories | ⏳ Pending |
| 1.10 | Create Initial Migration | ⏳ Pending |
| 1.11 | Configure ASP.NET Core Identity | ✅ Partial |
| 1.12 | Create Seed Data | ⏳ Pending |
| 1.13 | Configure Dependency Injection | ✅ Partial |

### PHASE 2: PRODUCT CATALOG (Weeks 4-5)
*See full task list for detailed sub-tasks*

### PHASE 3: SHOPPING & CHECKOUT (Weeks 6-8)
*See full task list for detailed sub-tasks*

### PHASE 4: PAYMENTS & SHIPPING (Weeks 9-10)
*See full task list for detailed sub-tasks*

### PHASE 5: ORDER MANAGEMENT (Weeks 11-12)
*See full task list for detailed sub-tasks*

### PHASE 6: INVENTORY & REPORTING (Weeks 13-14)
*See full task list for detailed sub-tasks*

### PHASE 7: POLISH & OPTIMIZATION (Weeks 15-16)
*See full task list for detailed sub-tasks*

---

## Domain Layer Overview

### TechMart.Domain Project Structure

```
TechMart.Domain/
├── Entities/
│   ├── Base/
│   │   └── BaseEntity.cs
│   ├── Product.cs
│   ├── Category.cs
│   ├── Brand.cs
│   ├── Order.cs
│   ├── OrderItem.cs
│   ├── Inventory.cs
│   ├── InventoryTransaction.cs
│   ├── Address.cs
│   ├── Payment.cs
│   ├── Shipment.cs
│   ├── ProductImage.cs
│   ├── ProductSpecification.cs
│   └── ShoppingCart.cs (includes ShoppingCartItem)
├── Enums/
│   ├── OrderStatus.cs
│   ├── PaymentStatus.cs
│   ├── PaymentMethod.cs
│   ├── ShippingMethod.cs
│   ├── ShipmentStatus.cs
│   ├── ShippingCarrier.cs
│   ├── AddressType.cs
│   ├── InventoryTransactionType.cs
│   ├── ReturnStatus.cs
│   ├── ReturnReason.cs
│   ├── ReturnItemCondition.cs
│   ├── DiscountType.cs
│   └── PurchaseOrderStatus.cs
├── ValueObjects/          (Task 1.5 - Pending)
└── Interfaces/            (Task 1.7 - Pending)
```

---

## Enums

| Enum | Values | Usage |
|------|--------|-------|
| **OrderStatus** | Pending, Processing, Shipped, Delivered, Cancelled, Returned | Order lifecycle |
| **PaymentStatus** | Pending, Authorized, Captured, Failed, Refunded | Payment state |
| **PaymentMethod** | CreditCard, DebitCard, PayPal, BankTransfer | Payment type |
| **ShippingMethod** | Ground, Express, Overnight | Shipping options |
| **ShipmentStatus** | Pending, LabelCreated, PickedUp, InTransit, OutForDelivery, Delivered, Exception | Shipment tracking |
| **ShippingCarrier** | UPS, FedEx, USPS, DHL | Carrier selection |
| **AddressType** | Shipping, Billing | Address purpose |
| **InventoryTransactionType** | Purchase, Sale, Return, Adjustment, Transfer | Inventory movements |
| **ReturnStatus** | Requested, Approved, Rejected, Received, Refunded | Return workflow |
| **ReturnReason** | Defective, WrongItem, NotAsDescribed, ChangedMind, Damaged | Return justification |
| **ReturnItemCondition** | New, OpenBox, Damaged | Item condition on return |
| **DiscountType** | Percentage, FixedAmount | Coupon/discount type |
| **PurchaseOrderStatus** | Draft, Sent, Confirmed, Shipped, Received, Cancelled | PO workflow |

**Task 1.4 Note:** `TransactionType` enum (Addition, Removal, Adjustment, Sale, Return) from the task list is covered by `InventoryTransactionType`.

---

## Value Objects

*Task 1.5 - Pending Implementation*

| Value Object | Properties | Purpose |
|--------------|------------|---------|
| **Money** | Amount (decimal), Currency (string) | Monetary values with currency |
| **Address** | Line1, Line2, City, State, Postal, Country | Reusable address structure |
| **Email** | Email (string) | Validated email value |

---

## Core Entities

### BaseEntity
*Task 1.6.2*

| Property | Type | Description |
|----------|------|-------------|
| Id | int | Primary key |
| CreatedAt | DateTime | Creation timestamp |
| UpdatedAt | DateTime? | Last update timestamp |
| CreatedBy | string? | Creator identifier |

### Product
*Task 1.6.3*

| Property | Type | Description |
|----------|------|-------------|
| Id | int | PK (inherited) |
| SKU | string | Stock Keeping Unit (unique) |
| Name | string | Product name |
| Description | string | Product description |
| CategoryId | int | FK to Category |
| BrandId | int | FK to Brand |
| Price | decimal | Selling price |
| CostPrice | decimal | Cost price |
| IsActive | bool | Availability flag |
| IsFeatured | bool | Featured product flag |
| Category | Category? | Navigation |
| Brand | Brand? | Navigation |
| Inventory | Inventory? | Navigation (1:1) |
| Images | ICollection<ProductImage> | Product images |
| Specifications | ICollection<ProductSpecification> | Key-value specs |

### Category
*Task 1.6.4*

| Property | Type | Description |
|----------|------|-------------|
| Id | int | PK |
| Name | string | Category name |
| Description | string | Category description |
| ParentCategoryId | int? | Self-reference for hierarchy |
| DisplayOrder | int | Sort order |
| IsActive | bool | Active flag |
| ParentCategory | Category? | Navigation |
| SubCategories | ICollection<Category> | Child categories |
| Products | ICollection<Product> | Products in category |

### Brand
*Task 1.6.5*

| Property | Type | Description |
|----------|------|-------------|
| Id | int | PK |
| Name | string | Brand name |
| Description | string | Brand description |
| LogoUrl | string? | Brand logo URL |
| Products | ICollection<Product> | Brand products |

### ApplicationUser (IdentityUser)
*Task 1.6.6* - Located in `TechMart.Infrastructure/Identity/`

| Property | Type | Description |
|----------|------|-------------|
| (IdentityUser) | - | Email, UserName, etc. |
| FirstName | string | First name |
| LastName | string | Last name |
| DateOfBirth | DateTime? | DOB |
| RegistrationDate | DateTime | Account creation |

### Order
*Task 1.6.7*

| Property | Type | Description |
|----------|------|-------------|
| Id | int | PK |
| OrderNumber | string | Unique order number |
| CustomerId | string | FK to Customer (Identity) |
| OrderDate | DateTime | Order date |
| OrderStatus | OrderStatus | Status enum |
| Subtotal | decimal | Items total |
| Tax | decimal | Tax amount |
| Shipping | decimal | Shipping cost |
| Total | decimal | Grand total |
| ShippingAddressId | int? | FK to Address |
| BillingAddressId | int? | FK to Address |
| ShippingAddress | Address? | Navigation |
| BillingAddress | Address? | Navigation |
| OrderItems | ICollection<OrderItem> | Line items |
| Payment | Payment? | Navigation (1:1) |
| Shipment | Shipment? | Navigation (1:1) |

### OrderItem
*Task 1.6.8*

| Property | Type | Description |
|----------|------|-------------|
| Id | int | PK |
| OrderId | int | FK to Order |
| ProductId | int | FK to Product |
| Quantity | int | Ordered quantity |
| UnitPrice | decimal | Price at time of order |
| ProductName | string | Snapshot |
| SKU | string | Snapshot |
| Subtotal | decimal | Calculated (UnitPrice × Quantity) |
| Order | Order? | Navigation |
| Product | Product? | Navigation |

### Inventory
*Task 1.6.9*

| Property | Type | Description |
|----------|------|-------------|
| Id | int | PK |
| ProductId | int | FK to Product (unique) |
| QuantityOnHand | int | Physical stock |
| QuantityReserved | int | Reserved for orders |
| QuantityAvailable | int | Computed (OnHand - Reserved) |
| ReorderPoint | int | Low stock threshold |
| ReorderQuantity | int | Restock quantity |
| WarehouseLocation | string | Storage location |
| LastRestockDate | DateTime? | Last restock |
| Product | Product? | Navigation |
| Transactions | ICollection<InventoryTransaction> | Transaction history |

### Address
*Task 1.6.10*

| Property | Type | Description |
|----------|------|-------------|
| Id | int | PK |
| CustomerId | string | FK to Customer |
| FirstName | string | First name |
| LastName | string | Last name |
| AddressLine1 | string | Street address |
| AddressLine2 | string? | Apt/Suite |
| City | string | City |
| State | string | State/Province |
| PostalCode | string | ZIP/Postal |
| Country | string | Country |
| AddressType | AddressType | Shipping or Billing |
| IsDefault | bool | Default address flag |
| ShippingOrders | ICollection<Order> | Orders using as shipping |
| BillingOrders | ICollection<Order> | Orders using as billing |

### Payment
*Task 1.6.11*

| Property | Type | Description |
|----------|------|-------------|
| Id | int | PK |
| OrderId | int | FK to Order (1:1) |
| PaymentMethod | PaymentMethod | CreditCard, PayPal, etc. |
| PaymentStatus | PaymentStatus | Status enum |
| Amount | decimal | Payment amount |
| TransactionId | string? | Gateway transaction ID |
| PaymentGateway | string? | Gateway name |
| AuthorizationCode | string? | Auth code |
| PaymentDate | DateTime? | When paid |
| Order | Order? | Navigation |

### Shipment
*Task 1.6.12*

| Property | Type | Description |
|----------|------|-------------|
| Id | int | PK |
| OrderId | int | FK to Order (1:1) |
| Carrier | ShippingCarrier | UPS, FedEx, etc. |
| ShippingMethod | ShippingMethod | Ground, Express, etc. |
| TrackingNumber | string? | Carrier tracking |
| ShippingCost | decimal | Shipping fee |
| Weight | decimal | Package weight |
| ShipmentDate | DateTime? | When shipped |
| EstimatedDeliveryDate | DateTime? | ETA |
| ActualDeliveryDate | DateTime? | Delivered date |
| ShipmentStatus | ShipmentStatus | Status enum |
| Order | Order? | Navigation |

### ShoppingCart & ShoppingCartItem
*Task 1.6.13, 1.6.14*

**Note:** Current domain model uses `UserId` and `Items`; task list specifies `CustomerId`, `SessionId`, and `CartItems`. Alignment may be needed.

| ShoppingCart Property | Type | Description |
|-----------------------|------|-------------|
| Id | Guid | PK |
| UserId | string | Customer/User identifier |
| Items | List<ShoppingCartItem> | Cart items |
| CreatedAt | DateTime | Creation |
| UpdatedAt | DateTime? | Last update |
| Total | decimal | Computed total |

| ShoppingCartItem Property | Type | Description |
|---------------------------|------|-------------|
| ProductId | Guid | Product reference |
| ProductName | string | Product name |
| UnitPrice | decimal | Unit price |
| Quantity | int | Quantity |

### ProductImage
*Task 2.16*

| Property | Type | Description |
|----------|------|-------------|
| Id | int | PK |
| ProductId | int | FK to Product |
| ImageUrl | string | Image path/URL |
| AltText | string? | Accessibility text |
| DisplayOrder | int | Sort order |
| IsPrimary | bool | Primary image flag |
| Product | Product? | Navigation |

### ProductSpecification
*Task 2.17*

| Property | Type | Description |
|----------|------|-------------|
| Id | int | PK |
| ProductId | int | FK to Product |
| Key | string | Spec name (e.g., "Weight") |
| Value | string | Spec value (e.g., "500g") |
| Product | Product? | Navigation |

### InventoryTransaction
*Task 6.5*

| Property | Type | Description |
|----------|------|-------------|
| Id | int | PK |
| InventoryId | int | FK to Inventory |
| TransactionType | InventoryTransactionType | Purchase, Sale, etc. |
| Quantity | int | Quantity change |
| UnitCost | decimal? | Cost per unit |
| ReferenceNumber | string? | PO/Order reference |
| Notes | string? | Transaction notes |
| Inventory | Inventory? | Navigation |

---

## DbContext

### TechMartDbContext
*Location: `TechMart.Infrastructure/Data/TechMartDbContext.cs`*

- **Base:** `IdentityDbContext<ApplicationUser>`
- **Assembly:** `TechMart.Infrastructure`

### DbSets

| DbSet | Entity |
|-------|--------|
| Products | Product |
| Categories | Category |
| Brands | Brand |
| Inventories | Inventory |
| InventoryTransactions | InventoryTransaction |
| ProductImages | ProductImage |
| ProductSpecifications | ProductSpecification |
| Orders | Order |
| OrderItems | OrderItem |
| Addresses | Address |
| Payments | Payment |
| Shipments | Shipment |
| ShoppingCarts | ShoppingCart |
| ShoppingCartItems | ShoppingCartItem |

### Configuration Application

```csharp
protected override void OnModelCreating(ModelBuilder builder)
{
    base.OnModelCreating(builder);
    builder.ApplyConfigurationsFromAssembly(typeof(TechMartDbContext).Assembly);
}
```

All `IEntityTypeConfiguration<T>` classes in the Infrastructure assembly are applied automatically.

---

## Entity Configurations

### ProductConfiguration

| Setting | Value |
|---------|-------|
| Table | Products |
| Key | Id |
| SKU | MaxLength(64), Required, Unique Index |
| Name | MaxLength(200), Required |
| Price | decimal(18,2) |
| CostPrice | decimal(18,2) |
| Category | FK, **Restrict** on delete |
| Brand | FK, **Restrict** on delete |
| Inventory | 1:1, **Cascade** on delete |
| Indexes | SKU (unique), CategoryId, BrandId, IsActive, IsFeatured, (CategoryId, IsActive) |

### CategoryConfiguration

| Setting | Value |
|---------|-------|
| Table | Categories |
| Key | Id |
| Name | MaxLength(100), Required, Index |
| Description | MaxLength(1000) |
| ParentCategory | Self-reference FK, Restrict |

### BrandConfiguration

| Setting | Value |
|---------|-------|
| Table | Brands |
| Key | Id |
| Name | MaxLength(100), Required, Unique Index |
| Description | MaxLength(1000) |
| LogoUrl | MaxLength(512) |

### OrderConfiguration

| Setting | Value |
|---------|-------|
| Table | Orders |
| Key | Id |
| OrderNumber | MaxLength(50), Required, Unique Index |
| Subtotal, Tax, Shipping, Total | decimal(18,2) |
| ShippingAddress | FK, Restrict |
| BillingAddress | FK, Restrict |
| OrderItems | 1:Many, Cascade |
| Payment | 1:1, Cascade |
| Shipment | 1:1, Cascade |

### OrderItemConfiguration

| Setting | Value |
|---------|-------|
| Table | OrderItems |
| Key | Id |
| ProductName | MaxLength(200), Required |
| SKU | MaxLength(64), Required |
| UnitPrice | decimal(18,2) |
| Order | FK, Cascade |
| Product | FK, Restrict |

### InventoryConfiguration

| Setting | Value |
|---------|-------|
| Table | Inventories |
| Key | Id |
| WarehouseLocation | MaxLength(100), Required |
| Product | 1:1, Cascade |

### InventoryTransactionConfiguration

| Setting | Value |
|---------|-------|
| Table | InventoryTransactions |
| Key | Id |
| ReferenceNumber | MaxLength(100) |
| Notes | MaxLength(1000) |
| Inventory | FK, Cascade |

### AddressConfiguration

| Setting | Value |
|---------|-------|
| Table | Addresses |
| Key | Id |
| CustomerId | MaxLength(450) |
| FirstName, LastName | MaxLength(100), Required |
| AddressLine1 | MaxLength(200), Required |
| AddressLine2 | MaxLength(200) |
| City, State | MaxLength(100), Required |
| PostalCode | MaxLength(20), Required |
| Country | MaxLength(100), Required |
| Index | (CustomerId, AddressType) |

### PaymentConfiguration

| Setting | Value |
|---------|-------|
| Table | Payments |
| Key | Id |
| Amount | decimal(18,2) |
| TransactionId | MaxLength(200) |
| PaymentGateway | MaxLength(100) |
| AuthorizationCode | MaxLength(100) |
| Order | 1:1 FK, Cascade |

### ShipmentConfiguration

| Setting | Value |
|---------|-------|
| Table | Shipments |
| Key | Id |
| TrackingNumber | MaxLength(200) |
| ShippingCost | decimal(18,2) |
| Weight | decimal(18,2) |
| Order | 1:1 FK, Cascade |

### ShoppingCartConfiguration

| Setting | Value |
|---------|-------|
| Table | ShoppingCarts |
| Key | Id |
| CustomerId | MaxLength(450) |
| SessionId | MaxLength(200) |
| CartItems | 1:Many, Cascade |

**Note:** Ensure domain `ShoppingCart` has `CustomerId`, `SessionId`, and `CartItems` (or `Items`) to match configuration.

### ProductImageConfiguration

| Setting | Value |
|---------|-------|
| Table | ProductImages |
| Key | Id |
| ImageUrl | MaxLength(512), Required |
| AltText | MaxLength(200) |
| Product | FK, Cascade |

### ProductSpecificationConfiguration

| Setting | Value |
|---------|-------|
| Table | ProductSpecifications |
| Key | Id |
| Key | MaxLength(100), Required |
| Value | MaxLength(500), Required |
| Product | FK, Cascade |

---

## Project Structure

### Current Solution

```
TechMart.sln
├── TechMart/                 (ASP.NET Core Razor Pages - Web)
├── TechMart.Domain/          (Class Library - Entities, Enums)
└── TechMart.Infrastructure/  (Class Library - EF, Identity, Configs)
```

### Pending Projects (from Task List)

- **TechMart.Application** - DTOs, Queries, Commands, Handlers, Services
- **TechMart.Web** - May be separate from TechMart (current Web project)

### Connection String (appsettings.json)

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=(localdb)\\MSSQLLocalDB;Database=TechMartDb;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True"
  }
}
```

---

## Entity Relationship Summary

```
Category (1) ──────────< (*) Product
Brand (1) ─────────────< (*) Product
Product (1) ───────────< (1) Inventory
Inventory (1) ─────────< (*) InventoryTransaction
Product (1) ───────────< (*) ProductImage
Product (1) ───────────< (*) ProductSpecification
Product (1) ───────────< (*) ProductReview
Product (1) ───────────< (*) WishlistItem
Product (1) ───────────< (*) PurchaseOrderItem

ApplicationUser (Identity) (1) < (*) Address
ApplicationUser (Identity) (1) < (*) Order
ApplicationUser (Identity) (1) < (1) Wishlist
Address (1) ──────────< (*) Order (Shipping/Billing)

Order (1) ────────────< (*) OrderItem
Order (1) ────────────< (*) OrderStatusHistory
Order (1) ────────────< (1) Payment
Order (1) ────────────< (1) Shipment
Order (*) ────────────> (0..1) Coupon
OrderItem (*) ────────> (1) Product

Supplier (1) ─────────< (*) PurchaseOrder
PurchaseOrder (1) ────< (*) PurchaseOrderItem
PurchaseOrderItem (*) ─> (1) Product

ShoppingCart (1) ─────< (*) ShoppingCartItem
ShoppingCartItem (*) ──> (1) Product

Wishlist (1) ─────────< (*) WishlistItem
WishlistItem (*) ──────> (1) Product
```

---

*Last updated: Based on current codebase and implementation task list.*
