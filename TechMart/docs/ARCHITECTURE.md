# TechMart E-Commerce - Architecture

> **Note:** `docs/architecture.svg` was not found. This document describes the implemented architecture based on the task list and Clean Architecture patterns.

---

## Layer Overview

```
┌─────────────────────────────────────────────────────────────────────┐
│                         TechMart.Web (Razor Pages)                   │
│                         - Pages, Views                               │
└─────────────────────────────────────────────────────────────────────┘
                                    │
                                    ▼
┌─────────────────────────────────────────────────────────────────────┐
│                     TechMart.Infrastructure                          │
│  - DbContext, Repositories, UnitOfWork                               │
│  - Identity, Configurations, DbInitializer                           │
└─────────────────────────────────────────────────────────────────────┘
                                    │
                                    ▼
┌─────────────────────────────────────────────────────────────────────┐
│                       TechMart.Domain                                │
│  - Entities, Value Objects, Enums                                    │
│  - Interfaces (IRepository, IUnitOfWork, etc.)                       │
└─────────────────────────────────────────────────────────────────────┘
```

---

## Domain Layer (TechMart.Domain)

### Value Objects
| Type | Purpose |
|------|---------|
| **Money** | Monetary values with currency, arithmetic operators |
| **AddressValue** | Reusable address structure (Line1, City, State, PostalCode, Country) |
| **Email** | Validated email value with Create/TryCreate |

### Interfaces
| Interface | Purpose |
|-----------|---------|
| **IRepository\<T\>** | Generic CRUD (GetByIdAsync, GetAllAsync, FindAsync, AddAsync, UpdateAsync, DeleteAsync) |
| **IUnitOfWork** | Transaction management (SaveChangesAsync, BeginTransactionAsync, CommitAsync, RollbackAsync) |
| **IProductRepository** | Product-specific (GetBySkuAsync, GetByCategoryIdAsync, GetFeaturedAsync, SearchAsync) |
| **IOrderRepository** | Order-specific (GetByOrderNumberAsync, GetByCustomerIdAsync, GetByStatusAsync) |
| **IInventoryRepository** | Inventory-specific (GetByProductIdAsync, GetLowStockAsync) |
| **ICartRepository** | Cart lookup (GetByCustomerIdAsync, GetBySessionIdAsync) |
| **IAddressRepository** | Address lookup (GetByCustomerIdAsync, GetDefaultByCustomerAndTypeAsync) |

### Entities
All entities inherit from `BaseEntity` (Id, CreatedAt, UpdatedAt, CreatedBy). See IMPLEMENTATION_DOCUMENTATION.md for full list.

---

## Infrastructure Layer (TechMart.Infrastructure)

### Repositories
| Implementation | Implements |
|----------------|------------|
| **GenericRepository\<T\>** | IRepository\<T\> |
| **ProductRepository** | IProductRepository, IRepository\<Product\> |
| **OrderRepository** | IOrderRepository, IRepository\<Order\> |
| **InventoryRepository** | IInventoryRepository, IRepository\<Inventory\> |
| **AddressRepository** | IAddressRepository, IRepository\<Address\> |
| **CartRepository** | ICartRepository |
| **ApplicationUserRepository** | IApplicationUserRepository |
| **UnitOfWork** | IUnitOfWork |

### Data
| Component | Purpose |
|-----------|---------|
| **TechMartDbContext** | EF Core DbContext (Identity + entities) |
| **DbInitializer** | Seed roles, admin user, categories, brands, products |
| **Entity Configurations** | IEntityTypeConfiguration for all entities |

### Identity
| Component | Purpose |
|-----------|---------|
| **ApplicationUser** | IdentityUser with FirstName, LastName, DateOfBirth, RegistrationDate |
| **IdentityConfiguration** | Password, lockout, user, sign-in settings |

### Dependency Injection
| Service | Registration |
|---------|--------------|
| TechMartDbContext | Scoped |
| IUnitOfWork | Scoped |
| IProductRepository, IOrderRepository, IInventoryRepository | Scoped |
| IAddressRepository, ICartRepository, IApplicationUserRepository | Scoped |
| IRepository\<Category\>, IRepository\<Brand\> | Scoped (GenericRepository) |

---

## Project References

```
TechMart (Web)
  └── TechMart.Infrastructure

TechMart.Infrastructure
  └── TechMart.Domain
```

---

## Startup Flow

1. `Program.cs` calls `AddInfrastructure(builder.Configuration)`
2. In Development, `DbInitializer.InitializeAsync` seeds database
3. `UseAuthentication()` and `UseAuthorization()` in pipeline
