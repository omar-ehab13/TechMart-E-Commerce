# TechMart E-Commerce - Implementation Task List

## PHASE 1: FOUNDATION & SETUP (Weeks 1-3)

### Task 1.1: Project Setup
- 1.1.1: Install .NET 8.0 SDK and Visual Studio/VS Code
- 1.1.2: Create blank solution file (TechMart.sln)
- 1.1.3: Create project structure with 4 class libraries
  - 1.1.3.1: Create TechMart.Domain project (Class Library)
  - 1.1.3.2: Create TechMart.Application project (Class Library)
  - 1.1.3.3: Create TechMart.Infrastructure project (Class Library)
  - 1.1.3.4: Create TechMart.Web project (ASP.NET Core Razor Pages)
- 1.1.4: Set up project references (Web → Application → Domain, Infrastructure → Domain)
- 1.1.5: Initialize Git repository
- 1.1.6: Create .gitignore file for .NET projects
- 1.1.7: Create initial README.md
- 1.1.8: Push to remote repository (GitHub/GitLab/Azure DevOps)

### Task 1.2: Install NuGet Packages
- 1.2.1: Install Entity Framework Core packages in Infrastructure
  - 1.2.1.1: Microsoft.EntityFrameworkCore
  - 1.2.1.2: Microsoft.EntityFrameworkCore.SqlServer
  - 1.2.1.3: Microsoft.EntityFrameworkCore.Tools
  - 1.2.1.4: Microsoft.EntityFrameworkCore.Design
- 1.2.2: Install Identity packages in Infrastructure
  - 1.2.2.1: Microsoft.AspNetCore.Identity.EntityFrameworkCore
- 1.2.3: Install AutoMapper in Application
  - 1.2.3.1: AutoMapper
  - 1.2.3.2: AutoMapper.Extensions.Microsoft.DependencyInjection
- 1.2.4: Install FluentValidation in Application
  - 1.2.4.1: FluentValidation
  - 1.2.4.2: FluentValidation.AspNetCore
- 1.2.5: Install MediatR in Application
  - 1.2.5.1: MediatR
  - 1.2.5.2: MediatR.Extensions.Microsoft.DependencyInjection
- 1.2.6: Install Serilog in Web
  - 1.2.6.1: Serilog.AspNetCore
  - 1.2.6.2: Serilog.Sinks.Console
  - 1.2.6.3: Serilog.Sinks.File

### Task 1.3: Database Setup
- 1.3.1: Install SQL Server (LocalDB or Full Instance)
- 1.3.2: Create TechMart database
- 1.3.3: Configure connection string in appsettings.json
- 1.3.4: Configure connection string in appsettings.Development.json
- 1.3.5: Set up User Secrets for development

### Task 1.4: Create Domain Layer - Enums
- 1.4.1: Create Enums folder in Domain project
- 1.4.2: Create OrderStatus enum (Pending, Processing, Shipped, Delivered, Cancelled)
- 1.4.3: Create PaymentStatus enum (Pending, Authorized, Captured, Failed, Refunded)
- 1.4.4: Create PaymentMethod enum (CreditCard, DebitCard, PayPal)
- 1.4.5: Create ShippingMethod enum (Standard, Express, Overnight, International)
- 1.4.6: Create ShipmentStatus enum (Pending, InTransit, Delivered, Returned)
- 1.4.7: Create AddressType enum (Shipping, Billing)
- 1.4.8: Create TransactionType enum (Addition, Removal, Adjustment, Sale, Return)

### Task 1.5: Create Domain Layer - Value Objects
- 1.5.1: Create ValueObjects folder in Domain project
- 1.5.2: Create Money value object
  - 1.5.2.1: Add Amount property (decimal)
  - 1.5.2.2: Add Currency property (string)
  - 1.5.2.3: Implement equality methods
  - 1.5.2.4: Implement arithmetic operators
- 1.5.3: Create Address value object
  - 1.5.3.1: Add address properties (Line1, Line2, City, State, Postal, Country)
  - 1.5.3.2: Implement validation logic
  - 1.5.3.3: Implement equality methods
- 1.5.4: Create Email value object
  - 1.5.4.1: Add email property
  - 1.5.4.2: Implement validation logic
  - 1.5.4.3: Implement equality methods

### Task 1.6: Create Domain Layer - Core Entities
- 1.6.1: Create Entities folder in Domain project
- 1.6.2: Create BaseEntity abstract class
  - 1.6.2.1: Add Id property
  - 1.6.2.2: Add CreatedAt property
  - 1.6.2.3: Add UpdatedAt property
- 1.6.3: Create Product entity
  - 1.6.3.1: Add ProductId, SKU, Name, Description
  - 1.6.3.2: Add Price, CostPrice properties
  - 1.6.3.3: Add CategoryId, BrandId (navigation properties)
  - 1.6.3.4: Add IsActive, IsFeatured flags
- 1.6.4: Create Category entity
  - 1.6.4.1: Add CategoryId, Name, Description
  - 1.6.4.2: Add ParentCategoryId (self-reference)
  - 1.6.4.3: Add DisplayOrder, IsActive
  - 1.6.4.4: Add Products navigation property
- 1.6.5: Create Brand entity
  - 1.6.5.1: Add BrandId, Name, Description
  - 1.6.5.2: Add LogoUrl property
  - 1.6.5.3: Add Products navigation property
- 1.6.6: Create Customer entity (extends IdentityUser)
  - 1.6.6.1: Add FirstName, LastName
  - 1.6.6.2: Add DateOfBirth property
  - 1.6.6.3: Add RegistrationDate
- 1.6.7: Create Order entity
  - 1.6.7.1: Add OrderId, OrderNumber, CustomerId
  - 1.6.7.2: Add OrderDate, OrderStatus
  - 1.6.7.3: Add amount properties (Subtotal, Tax, Shipping, Total)
  - 1.6.7.4: Add ShippingAddressId, BillingAddressId
  - 1.6.7.5: Add OrderItems navigation property
- 1.6.8: Create OrderItem entity
  - 1.6.8.1: Add OrderItemId, OrderId, ProductId
  - 1.6.8.2: Add Quantity, UnitPrice
  - 1.6.8.3: Add ProductName, SKU (snapshot)
  - 1.6.8.4: Add calculated Subtotal property
- 1.6.9: Create Inventory entity
  - 1.6.9.1: Add InventoryId, ProductId
  - 1.6.9.2: Add QuantityOnHand, QuantityReserved
  - 1.6.9.3: Add QuantityAvailable (computed)
  - 1.6.9.4: Add ReorderPoint, ReorderQuantity
  - 1.6.9.5: Add WarehouseLocation, LastRestockDate
- 1.6.10: Create Address entity
  - 1.6.10.1: Add AddressId, CustomerId
  - 1.6.10.2: Add address fields (FirstName, LastName, AddressLine1, etc.)
  - 1.6.10.3: Add IsDefault flag
- 1.6.11: Create Payment entity
  - 1.6.11.1: Add PaymentId, OrderId
  - 1.6.11.2: Add PaymentMethod, PaymentStatus, Amount
  - 1.6.11.3: Add TransactionId, PaymentGateway
  - 1.6.11.4: Add AuthorizationCode, PaymentDate
- 1.6.12: Create Shipment entity
  - 1.6.12.1: Add ShipmentId, OrderId
  - 1.6.12.2: Add carrier and method properties
  - 1.6.12.3: Add TrackingNumber, ShippingCost, Weight
  - 1.6.12.4: Add dates (Shipment, EstimatedDelivery, ActualDelivery)
- 1.6.13: Create ShoppingCart entity
  - 1.6.13.1: Add CartId, CustomerId, SessionId
  - 1.6.13.2: Add CartItems navigation property
- 1.6.14: Create ShoppingCartItem entity
  - 1.6.14.1: Add CartItemId, CartId, ProductId
  - 1.6.14.2: Add Quantity, UnitPrice
  - 1.6.14.3: Add AddedAt timestamp

### Task 1.7: Create Domain Layer - Interfaces
- 1.7.1: Create Interfaces folder in Domain project
- 1.7.2: Create IRepository<T> interface
  - 1.7.2.1: Add GetByIdAsync method
  - 1.7.2.2: Add GetAllAsync method
  - 1.7.2.3: Add AddAsync method
  - 1.7.2.4: Add UpdateAsync method
  - 1.7.2.5: Add DeleteAsync method
  - 1.7.2.6: Add FindAsync method (with predicate)
- 1.7.3: Create IUnitOfWork interface
  - 1.7.3.1: Add SaveChangesAsync method
  - 1.7.3.2: Add BeginTransactionAsync method
  - 1.7.3.3: Add CommitAsync method
  - 1.7.3.4: Add RollbackAsync method
- 1.7.4: Create specific repository interfaces
  - 1.7.4.1: Create IProductRepository interface
  - 1.7.4.2: Create IOrderRepository interface
  - 1.7.4.3: Create IInventoryRepository interface
  - 1.7.4.4: Create ICustomerRepository interface

### Task 1.8: Create Infrastructure Layer - DbContext
- 1.8.1: Create Data folder in Infrastructure project
- 1.8.2: Create ApplicationDbContext class
  - 1.8.2.1: Inherit from IdentityDbContext<Customer>
  - 1.8.2.2: Add DbSet properties for all entities
  - 1.8.2.3: Override OnModelCreating method
- 1.8.3: Create Configurations folder
- 1.8.4: Create entity configurations (IEntityTypeConfiguration)
  - 1.8.4.1: Create ProductConfiguration
  - 1.8.4.2: Create CategoryConfiguration
  - 1.8.4.3: Create BrandConfiguration
  - 1.8.4.4: Create OrderConfiguration
  - 1.8.4.5: Create OrderItemConfiguration
  - 1.8.4.6: Create InventoryConfiguration
  - 1.8.4.7: Create AddressConfiguration
  - 1.8.4.8: Create PaymentConfiguration
  - 1.8.4.9: Create ShipmentConfiguration
  - 1.8.4.10: Create ShoppingCartConfiguration
  - 1.8.4.11: Create ShoppingCartItemConfiguration
- 1.8.5: Apply configurations in OnModelCreating

### Task 1.9: Create Infrastructure Layer - Repositories
- 1.9.1: Create Repositories folder in Infrastructure project
- 1.9.2: Create GenericRepository<T> class
  - 1.9.2.1: Implement IRepository<T> interface
  - 1.9.2.2: Inject ApplicationDbContext
  - 1.9.2.3: Implement all CRUD methods
- 1.9.3: Create UnitOfWork class
  - 1.9.3.1: Implement IUnitOfWork interface
  - 1.9.3.2: Implement transaction methods
- 1.9.4: Create specific repository implementations
  - 1.9.4.1: Create ProductRepository class
  - 1.9.4.2: Create OrderRepository class
  - 1.9.4.3: Create InventoryRepository class
  - 1.9.4.4: Create CustomerRepository class

### Task 1.10: Create Initial Migration
- 1.10.1: Set Infrastructure as startup project
- 1.10.2: Run Add-Migration InitialCreate
- 1.10.3: Review generated migration files
- 1.10.4: Run Update-Database
- 1.10.5: Verify tables created in SQL Server
- 1.10.6: Add database indexes migration
- 1.10.7: Apply index migration

### Task 1.11: Configure ASP.NET Core Identity
- 1.11.1: Create Identity folder in Infrastructure
- 1.11.2: Configure Identity in ApplicationDbContext
- 1.11.3: Create IdentityConfiguration class
  - 1.11.3.1: Configure password requirements
  - 1.11.3.2: Configure lockout settings
  - 1.11.3.3: Configure user settings
  - 1.11.3.4: Configure sign-in settings
- 1.11.4: Register Identity services in Program.cs
- 1.11.5: Add authentication middleware to pipeline

### Task 1.12: Create Seed Data
- 1.12.1: Create DbInitializer class
- 1.12.2: Seed default roles (Customer, Staff, Manager, Admin)
- 1.12.3: Seed admin user
- 1.12.4: Seed sample categories
- 1.12.5: Seed sample brands
- 1.12.6: Seed sample products
- 1.12.7: Call DbInitializer in Program.cs

### Task 1.13: Configure Dependency Injection
- 1.13.1: Create DependencyInjection class in Infrastructure
- 1.13.2: Register DbContext
- 1.13.3: Register repositories
- 1.13.4: Register UnitOfWork
- 1.13.5: Register Identity services
- 1.13.6: Configure AutoMapper
- 1.13.7: Configure FluentValidation
- 1.13.8: Configure MediatR
- 1.13.9: Configure Serilog
- 1.13.10: Call DI configuration in Program.cs

---

## PHASE 2: PRODUCT CATALOG (Weeks 4-5)

### Task 2.1: Create Application Layer - Product DTOs
- 2.1.1: Create DTOs folder in Application project
- 2.1.2: Create ProductDto class
  - 2.1.2.1: Add all product properties
  - 2.1.2.2: Add Category and Brand names
- 2.1.3: Create ProductListDto class (for listings)
- 2.1.4: Create ProductDetailDto class (for detail page)
- 2.1.5: Create CreateProductDto class
- 2.1.6: Create UpdateProductDto class
- 2.1.7: Create CategoryDto class
- 2.1.8: Create BrandDto class

### Task 2.2: Create Application Layer - Product Queries
- 2.2.1: Create Queries folder in Application project
- 2.2.2: Create GetAllProductsQuery class
  - 2.2.2.1: Add pagination parameters (PageNumber, PageSize)
  - 2.2.2.2: Add filter parameters (CategoryId, BrandId, SearchTerm)
  - 2.2.2.3: Add sorting parameters
- 2.2.3: Create GetProductByIdQuery class
- 2.2.4: Create GetProductBySkuQuery class
- 2.2.5: Create SearchProductsQuery class
- 2.2.6: Create GetFeaturedProductsQuery class
- 2.2.7: Create GetProductsByCategoryQuery class

### Task 2.3: Create Application Layer - Product Commands
- 2.3.1: Create Commands folder in Application project
- 2.3.2: Create CreateProductCommand class
- 2.3.3: Create UpdateProductCommand class
- 2.3.4: Create DeleteProductCommand class
- 2.3.5: Create UpdateProductStockCommand class

### Task 2.4: Create Application Layer - Product Handlers
- 2.4.1: Create Handlers folder in Application project
- 2.4.2: Create GetAllProductsQueryHandler class
  - 2.4.2.1: Implement IRequestHandler interface
  - 2.4.2.2: Inject IProductRepository
  - 2.4.2.3: Implement Handle method with filtering and pagination
- 2.4.3: Create GetProductByIdQueryHandler class
- 2.4.4: Create GetProductBySkuQueryHandler class
- 2.4.5: Create SearchProductsQueryHandler class
- 2.4.6: Create GetFeaturedProductsQueryHandler class
- 2.4.7: Create CreateProductCommandHandler class
- 2.4.8: Create UpdateProductCommandHandler class
- 2.4.9: Create DeleteProductCommandHandler class

### Task 2.5: Create Application Layer - Product Validators
- 2.5.1: Create Validators folder in Application project
- 2.5.2: Create CreateProductValidator class
  - 2.5.2.1: Validate Name (required, max length)
  - 2.5.2.2: Validate SKU (required, unique, format)
  - 2.5.2.3: Validate Price (greater than 0)
  - 2.5.2.4: Validate CategoryId (exists)
- 2.5.3: Create UpdateProductValidator class
- 2.5.4: Create ProductSearchValidator class

### Task 2.6: Create Application Layer - AutoMapper Profiles
- 2.6.1: Create Mappers folder in Application project
- 2.6.2: Create ProductMappingProfile class
  - 2.6.2.1: Map Product to ProductDto
  - 2.6.2.2: Map Product to ProductListDto
  - 2.6.2.3: Map Product to ProductDetailDto
  - 2.6.2.4: Map CreateProductDto to Product
  - 2.6.2.5: Map UpdateProductDto to Product

### Task 2.7: Create Product Service
- 2.7.1: Create Services folder in Application project
- 2.7.2: Create IProductService interface
  - 2.7.2.1: Define GetAllProductsAsync method
  - 2.7.2.2: Define GetProductByIdAsync method
  - 2.7.2.3: Define SearchProductsAsync method
  - 2.7.2.4: Define CreateProductAsync method
  - 2.7.2.5: Define UpdateProductAsync method
  - 2.7.2.6: Define DeleteProductAsync method
- 2.7.3: Create ProductService class
  - 2.7.3.1: Implement IProductService interface
  - 2.7.3.2: Inject IMediator
  - 2.7.3.3: Implement all methods using MediatR

### Task 2.8: Create Category Management
- 2.8.1: Create CategoryDto class
- 2.8.2: Create GetAllCategoriesQuery class
- 2.8.3: Create GetCategoryByIdQuery class
- 2.8.4: Create CreateCategoryCommand class
- 2.8.5: Create UpdateCategoryCommand class
- 2.8.6: Create DeleteCategoryCommand class
- 2.8.7: Create corresponding handlers
- 2.8.8: Create ICategoryService interface
- 2.8.9: Create CategoryService implementation

### Task 2.9: Create Brand Management
- 2.9.1: Create BrandDto class
- 2.9.2: Create GetAllBrandsQuery class
- 2.9.3: Create GetBrandByIdQuery class
- 2.9.4: Create CreateBrandCommand class
- 2.9.5: Create UpdateBrandCommand class
- 2.9.6: Create DeleteBrandCommand class
- 2.9.7: Create corresponding handlers
- 2.9.8: Create IBrandService interface
- 2.9.9: Create BrandService implementation

### Task 2.10: Create Presentation Layer - Shared Layout
- 2.10.1: Create Pages folder structure in Web project
- 2.10.2: Update _Layout.cshtml
  - 2.10.2.1: Add Bootstrap 5 CDN links
  - 2.10.2.2: Create navigation menu
  - 2.10.2.3: Add user authentication display
  - 2.10.2.4: Add shopping cart icon with count
  - 2.10.2.5: Add footer
- 2.10.3: Create _ViewImports.cshtml
- 2.10.4: Create _ViewStart.cshtml
- 2.10.5: Create site.css with custom styles
- 2.10.6: Create site.js for common JavaScript

### Task 2.11: Create Product Pages - Listing
- 2.11.1: Create Products folder in Pages
- 2.11.2: Create Index.cshtml (product listing)
- 2.11.3: Create Index.cshtml.cs PageModel
  - 2.11.3.1: Inject IProductService
  - 2.11.3.2: Add properties for products, pagination, filters
  - 2.11.3.3: Implement OnGetAsync method
  - 2.11.3.4: Add filtering logic
  - 2.11.3.5: Add pagination logic
- 2.11.4: Create product card partial view (_ProductCard.cshtml)
- 2.11.5: Add search bar in Index.cshtml
- 2.11.6: Add category filter sidebar
- 2.11.7: Add brand filter
- 2.11.8: Add price range filter
- 2.11.9: Add sorting dropdown
- 2.11.10: Add pagination controls

### Task 2.12: Create Product Pages - Detail
- 2.12.1: Create Details.cshtml
- 2.12.2: Create Details.cshtml.cs PageModel
  - 2.12.2.1: Inject IProductService
  - 2.12.2.2: Add Product property
  - 2.12.2.3: Implement OnGetAsync method
- 2.12.3: Design product image gallery
- 2.12.4: Display product specifications
- 2.12.5: Show stock availability
- 2.12.6: Add "Add to Cart" button
- 2.12.7: Display related products section
- 2.12.8: Add product reviews section (placeholder)

### Task 2.13: Create Admin Product Pages
- 2.13.1: Create Admin folder in Pages
- 2.13.2: Create Admin/Products folder
- 2.13.3: Create Admin/Products/Index.cshtml (admin product list)
- 2.13.4: Create Admin/Products/Index.cshtml.cs
  - 2.13.4.1: Add [Authorize(Roles = "Admin,Manager")] attribute
  - 2.13.4.2: Display all products with edit/delete buttons
- 2.13.5: Create Admin/Products/Create.cshtml
- 2.13.6: Create Admin/Products/Create.cshtml.cs
  - 2.13.6.1: Add form for product creation
  - 2.13.6.2: Implement OnPostAsync method
  - 2.13.6.3: Add validation
- 2.13.7: Create Admin/Products/Edit.cshtml
- 2.13.8: Create Admin/Products/Edit.cshtml.cs
  - 2.13.8.1: Load product data in OnGetAsync
  - 2.13.8.2: Implement OnPostAsync for updates
- 2.13.9: Create Admin/Products/Delete.cshtml
- 2.13.10: Create Admin/Products/Delete.cshtml.cs

### Task 2.14: Create Category Management Pages
- 2.14.1: Create Admin/Categories folder
- 2.14.2: Create Admin/Categories/Index.cshtml
- 2.14.3: Create Admin/Categories/Index.cshtml.cs
- 2.14.4: Create Admin/Categories/Create.cshtml
- 2.14.5: Create Admin/Categories/Create.cshtml.cs
- 2.14.6: Create Admin/Categories/Edit.cshtml
- 2.14.7: Create Admin/Categories/Edit.cshtml.cs
- 2.14.8: Create Admin/Categories/Delete.cshtml
- 2.14.9: Create Admin/Categories/Delete.cshtml.cs

### Task 2.15: Create Brand Management Pages
- 2.15.1: Create Admin/Brands folder
- 2.15.2: Create Admin/Brands/Index.cshtml
- 2.15.3: Create Admin/Brands/Index.cshtml.cs
- 2.15.4: Create Admin/Brands/Create.cshtml
- 2.15.5: Create Admin/Brands/Create.cshtml.cs
- 2.15.6: Create Admin/Brands/Edit.cshtml
- 2.15.7: Create Admin/Brands/Edit.cshtml.cs
- 2.15.8: Create Admin/Brands/Delete.cshtml
- 2.15.9: Create Admin/Brands/Delete.cshtml.cs

### Task 2.16: Implement Product Image Upload
- 2.16.1: Create ProductImage entity
- 2.16.2: Create ProductImage entity configuration
- 2.16.3: Add migration for ProductImages table
- 2.16.4: Create IFileStorageService interface
- 2.16.5: Create LocalFileStorageService implementation
- 2.16.6: Add image upload in Create/Edit product pages
- 2.16.7: Implement multiple image support
- 2.16.8: Add image deletion functionality

### Task 2.17: Implement Product Specifications
- 2.17.1: Create ProductSpecification entity
- 2.17.2: Create ProductSpecification entity configuration
- 2.17.3: Add migration for ProductSpecifications table
- 2.17.4: Add specifications in product create/edit forms
- 2.17.5: Display specifications on product detail page
- 2.17.6: Allow dynamic add/remove of specification fields

---

## PHASE 3: SHOPPING & CHECKOUT (Weeks 6-8)

### Task 3.1: Create Shopping Cart Application Layer
- 3.1.1: Create CartDto class
- 3.1.2: Create CartItemDto class
- 3.1.3: Create AddToCartCommand class
- 3.1.4: Create UpdateCartItemCommand class
- 3.1.5: Create RemoveFromCartCommand class
- 3.1.6: Create GetCartQuery class
- 3.1.7: Create ClearCartCommand class
- 3.1.8: Create corresponding handlers
- 3.1.9: Create ICartService interface
- 3.1.10: Create CartService implementation

### Task 3.2: Implement Cart Repository
- 3.2.1: Create ICartRepository interface
- 3.2.2: Create CartRepository implementation
  - 3.2.2.1: Implement GetCartByCustomerIdAsync
  - 3.2.2.2: Implement GetCartBySessionIdAsync
  - 3.2.2.3: Implement AddItemAsync
  - 3.2.2.4: Implement UpdateItemAsync
  - 3.2.2.5: Implement RemoveItemAsync
  - 3.2.2.6: Implement ClearCartAsync

### Task 3.3: Create Cart Pages
- 3.3.1: Create Cart folder in Pages
- 3.3.2: Create Cart/Index.cshtml
- 3.3.3: Create Cart/Index.cshtml.cs
  - 3.3.3.1: Inject ICartService
  - 3.3.3.2: Load cart items in OnGetAsync
  - 3.3.3.3: Calculate subtotal, tax, total
  - 3.3.3.4: Implement OnPostUpdateQuantityAsync
  - 3.3.3.5: Implement OnPostRemoveItemAsync
- 3.3.4: Display cart items table
- 3.3.5: Add quantity update controls
- 3.3.6: Add remove item buttons
- 3.3.7: Display order summary
- 3.3.8: Add "Continue Shopping" button
- 3.3.9: Add "Proceed to Checkout" button

### Task 3.4: Implement Add to Cart Functionality
- 3.4.1: Add "Add to Cart" button on product detail page
- 3.4.2: Create AddToCart handler method in Details.cshtml.cs
- 3.4.3: Handle guest cart with session ID
- 3.4.4: Handle authenticated user cart
- 3.4.5: Validate stock availability before adding
- 3.4.6: Show success message after adding
- 3.4.7: Update cart icon count in header
- 3.4.8: Create AJAX endpoint for add to cart
- 3.4.9: Add loading spinner during add operation

### Task 3.5: Create Address Management
- 3.5.1: Create AddressDto class
- 3.5.2: Create GetAddressesByCustomerQuery class
- 3.5.3: Create GetAddressByIdQuery class
- 3.5.4: Create CreateAddressCommand class
- 3.5.5: Create UpdateAddressCommand class
- 3.5.6: Create DeleteAddressCommand class
- 3.5.7: Create SetDefaultAddressCommand class
- 3.5.8: Create corresponding handlers
- 3.5.9: Create IAddressService interface
- 3.5.10: Create AddressService implementation

### Task 3.6: Create Address Management Pages
- 3.6.1: Create Account/Addresses folder
- 3.6.2: Create Account/Addresses/Index.cshtml
- 3.6.3: Create Account/Addresses/Index.cshtml.cs
  - 3.6.3.1: Display all customer addresses
  - 3.6.3.2: Show default address indicator
- 3.6.4: Create Account/Addresses/Create.cshtml
- 3.6.5: Create Account/Addresses/Create.cshtml.cs
  - 3.6.5.1: Add address form
  - 3.6.5.2: Implement validation
- 3.6.6: Create Account/Addresses/Edit.cshtml
- 3.6.7: Create Account/Addresses/Edit.cshtml.cs
- 3.6.8: Create Account/Addresses/Delete.cshtml
- 3.6.9: Create Account/Addresses/Delete.cshtml.cs

### Task 3.7: Create Checkout Application Layer
- 3.7.1: Create CheckoutDto class
- 3.7.2: Create InitiateCheckoutCommand class
- 3.7.3: Create SelectShippingAddressCommand class
- 3.7.4: Create SelectBillingAddressCommand class
- 3.7.5: Create CalculateShippingCommand class
- 3.7.6: Create CalculateTaxCommand class
- 3.7.7: Create ValidateCheckoutCommand class
- 3.7.8: Create PlaceOrderCommand class
- 3.7.9: Create corresponding handlers
- 3.7.10: Create ICheckoutService interface
- 3.7.11: Create CheckoutService implementation

### Task 3.8: Create Checkout Pages - Step 1: Shipping
- 3.8.1: Create Checkout folder in Pages
- 3.8.2: Create Checkout/Shipping.cshtml
- 3.8.3: Create Checkout/Shipping.cshtml.cs
  - 3.8.3.1: Inject IAddressService and ICheckoutService
  - 3.8.3.2: Load saved addresses in OnGetAsync
  - 3.8.3.3: Allow selection of existing address
  - 3.8.3.4: Allow adding new shipping address
  - 3.8.3.5: Implement OnPostAsync to save selection
- 3.8.4: Add radio buttons for address selection
- 3.8.5: Add "Add New Address" form (hidden by default)
- 3.8.6: Add address validation
- 3.8.7: Add "Continue to Shipping Method" button

### Task 3.9: Create Checkout Pages - Step 2: Shipping Method
- 3.9.1: Create Checkout/ShippingMethod.cshtml
- 3.9.2: Create Checkout/ShippingMethod.cshtml.cs
  - 3.9.2.1: Inject ICheckoutService
  - 3.9.2.2: Load available shipping methods in OnGetAsync
  - 3.9.2.3: Calculate shipping costs
  - 3.9.2.4: Implement OnPostAsync to save selection
- 3.9.3: Display shipping method options with costs
- 3.9.4: Add estimated delivery dates
- 3.9.5: Add "Continue to Payment" button

### Task 3.10: Create Checkout Pages - Step 3: Payment
- 3.10.1: Create Checkout/Payment.cshtml
- 3.10.2: Create Checkout/Payment.cshtml.cs
  - 3.10.2.1: Inject ICheckoutService and IPaymentService
  - 3.10.2.2: Load order summary in OnGetAsync
  - 3.10.2.3: Display payment options
  - 3.10.2.4: Implement OnPostAsync for payment processing
- 3.10.3: Add payment method selection (Credit Card, PayPal)
- 3.10.4: Add billing address selection
- 3.10.5: Show order review summary
- 3.10.6: Add terms and conditions checkbox
- 3.10.7: Add "Place Order" button
- 3.10.8: Add loading indicator during processing

### Task 3.11: Create Order Confirmation Page
- 3.11.1: Create Checkout/Confirmation.cshtml
- 3.11.2: Create Checkout/Confirmation.cshtml.cs
  - 3.11.2.1: Inject IOrderService
  - 3.11.2.2: Load order details in OnGetAsync
  - 3.11.2.3: Display order number and status
- 3.11.3: Show order summary with items
- 3.11.4: Display shipping and billing addresses
- 3.11.5: Show estimated delivery date
- 3.11.6: Add "Track Order" button
- 3.11.7: Add "Continue Shopping" button
- 3.11.8: Display thank you message

### Task 3.12: Implement Guest Checkout
- 3.12.1: Allow guest users to proceed to checkout
- 3.12.2: Collect email for order confirmation
- 3.12.3: Store guest order with email reference
- 3.12.4: Send order confirmation email to guest
- 3.12.5: Create guest order lookup page
- 3.12.6: Allow guest to view order status by order number and email

### Task 3.13: Implement Checkout Validation
- 3.13.1: Create CheckoutValidator class
- 3.13.2: Validate cart is not empty
- 3.13.3: Validate all items are in stock
- 3.13.4: Validate shipping address completeness
- 3.13.5: Validate billing address completeness
- 3.13.6: Validate payment information
- 3.13.7: Show validation errors at each step

### Task 3.14: Implement Cart Session Management
- 3.14.1: Create session middleware for guest carts
- 3.14.2: Generate unique session ID for guests
- 3.14.3: Persist cart data in session
- 3.14.4: Merge guest cart with user cart on login
- 3.14.5: Clear cart after successful order
- 3.14.6: Implement cart expiration (30 days)

### Task 3.15: Create Shopping Cart Tag Helper
- 3.15.1: Create CartCountTagHelper class
- 3.15.2: Inject ICartService
- 3.15.3: Get cart item count
- 3.15.4: Render cart count badge
- 3.15.5: Add tag helper to _Layout.cshtml header
- 3.15.6: Update count dynamically with JavaScript

---

## PHASE 4: PAYMENTS & SHIPPING (Weeks 9-10)

### Task 4.1: Setup Stripe Integration
- 4.1.1: Create Stripe account (test mode)
- 4.1.2: Install Stripe.net NuGet package in Infrastructure
- 4.1.3: Add Stripe API keys to User Secrets
- 4.1.4: Add Stripe configuration to appsettings.json
- 4.1.5: Create Stripe configuration section

### Task 4.2: Create Payment Service Interface
- 4.2.1: Create IPaymentService interface in Application
  - 4.2.1.1: Define CreatePaymentIntentAsync method
  - 4.2.1.2: Define ConfirmPaymentAsync method
  - 4.2.1.3: Define RefundPaymentAsync method
  - 4.2.1.4: Define GetPaymentStatusAsync method
- 4.2.2: Create PaymentDto class
- 4.2.3: Create PaymentResultDto class

### Task 4.3: Implement Stripe Payment Service
- 4.3.1: Create Integrations folder in Infrastructure
- 4.3.2: Create StripePaymentService class
  - 4.3.2.1: Implement IPaymentService interface
  - 4.3.2.2: Configure StripeClient
  - 4.3.2.3: Implement CreatePaymentIntentAsync
  - 4.3.2.4: Implement ConfirmPaymentAsync
  - 4.3.2.5: Implement RefundPaymentAsync
  - 4.3.2.6: Implement GetPaymentStatusAsync
  - 4.3.2.7: Add error handling for Stripe exceptions
  - 4.3.2.8: Add logging

### Task 4.4: Integrate Stripe in Checkout
- 4.4.1: Add Stripe.js to Payment page
- 4.4.2: Create Stripe Elements for card input
- 4.4.3: Create client secret in Payment page OnGet
- 4.4.4: Pass client secret to JavaScript
- 4.4.5: Handle card submission with Stripe.js
- 4.4.6: Confirm payment on server-side
- 4.4.7: Create order after successful payment
- 4.4.8: Handle payment failures
- 4.4.9: Show error messages to user
- 4.4.10: Redirect to confirmation on success

### Task 4.5: Setup PayPal Integration (Optional)
- 4.5.1: Create PayPal developer account
- 4.5.2: Install PayPal SDK NuGet package
- 4.5.3: Add PayPal API keys to User Secrets
- 4.5.4: Create PayPalPaymentService class
- 4.5.5: Implement IPaymentService interface
- 4.5.6: Add PayPal buttons to Payment page
- 4.5.7: Handle PayPal callback
- 4.5.8: Create order after PayPal approval

### Task 4.6: Implement Payment Recording
- 4.6.1: Create Payment entity (if not done in Phase 1)
- 4.6.2: Create IPaymentRepository interface
- 4.6.3: Create PaymentRepository implementation
- 4.6.4: Create RecordPaymentCommand class
- 4.6.5: Create RecordPaymentCommandHandler
- 4.6.6: Save payment details in database
- 4.6.7: Link payment to order
- 4.6.8: Store transaction ID from payment gateway
- 4.6.9: Record payment status

### Task 4.7: Setup Shipping Integration (Shippo/EasyPost)
- 4.7.1: Choose shipping provider (Shippo recommended)
- 4.7.2: Create Shippo account
- 4.7.3: Install Shippo NuGet package (or use REST client)
- 4.7.4: Add Shippo API keys to User Secrets
- 4.7.5: Create Shippo configuration section

### Task 4.8: Create Shipping Service Interface
- 4.8.1: Create IShippingService interface in Application
  - 4.8.1.1: Define GetShippingRatesAsync method
  - 4.8.1.2: Define CreateShipmentAsync method
  - 4.8.1.3: Define GenerateLabelAsync method
  - 4.8.1.4: Define TrackShipmentAsync method
  - 4.8.1.5: Define CancelShipmentAsync method
- 4.8.2: Create ShippingRateDto class
- 4.8.3: Create ShippingLabelDto class
- 4.8.4: Create TrackingInfoDto class

### Task 4.9: Implement Shipping Service
- 4.9.1: Create ShippoShippingService class in Infrastructure
  - 4.9.1.1: Implement IShippingService interface
  - 4.9.1.2: Configure Shippo API client
  - 4.9.1.3: Implement GetShippingRatesAsync
  - 4.9.1.4: Implement CreateShipmentAsync
  - 4.9.1.5: Implement GenerateLabelAsync
  - 4.9.1.6: Implement TrackShipmentAsync
  - 4.9.1.7: Add error handling
  - 4.9.1.8: Add logging

### Task 4.10: Integrate Shipping Rates in Checkout
- 4.10.1: Modify ShippingMethod.cshtml.cs
- 4.10.2: Inject IShippingService
- 4.10.3: Get real-time shipping rates in OnGetAsync
- 4.10.4: Calculate rates based on cart weight and destination
- 4.10.5: Display live rates to customer
- 4.10.6: Store selected shipping method
- 4.10.7: Update order total with shipping cost
- 4.10.8: Handle shipping calculation errors

### Task 4.11: Implement Address Validation
- 4.11.1: Use Shippo address validation API
- 4.11.2: Validate address before checkout
- 4.11.3: Show suggestions for invalid addresses
- 4.11.4: Allow user to confirm or update address
- 4.11.5: Mark address as validated in database

### Task 4.12: Create Tax Calculation Service
- 4.12.1: Create ITaxService interface
  - 4.12.1.1: Define CalculateTaxAsync method
  - 4.12.1.2: Define GetTaxRateAsync method
- 4.12.2: Create TaxService implementation
  - 4.12.2.1: Implement basic tax calculation by state/province
  - 4.12.2.2: Add tax rates configuration
  - 4.12.2.3: Calculate tax based on shipping address
- 4.12.3: Integrate tax calculation in checkout
- 4.12.4: Display tax amount in order summary
- 4.12.5: Store tax amount in order

### Task 4.13: Implement Order Total Calculation
- 4.13.1: Create CalculateOrderTotalCommand
- 4.13.2: Create CalculateOrderTotalHandler
- 4.13.3: Calculate subtotal from cart items
- 4.13.4: Add shipping cost
- 4.13.5: Add tax amount
- 4.13.6: Apply discount codes (if any)
- 4.13.7: Calculate final total
- 4.13.8: Update order summary display
- 4.13.9: Recalculate on any changes

### Task 4.14: Create Order Entity Updates
- 4.14.1: Add PaymentIntentId field to Payment entity
- 4.14.2: Add ShipmentId field to Order entity
- 4.14.3: Add TrackingNumber to Shipment entity
- 4.14.4: Add LabelUrl to Shipment entity
- 4.14.5: Create migration for new fields
- 4.14.6: Apply migration

### Task 4.15: Implement Payment Webhooks
- 4.15.1: Create Webhooks folder in Web project
- 4.15.2: Create StripeWebhookController
  - 4.15.2.1: Add [AllowAnonymous] attribute
  - 4.15.2.2: Verify webhook signature
  - 4.15.2.3: Handle payment_intent.succeeded event
  - 4.15.2.4: Handle payment_intent.payment_failed event
  - 4.15.2.5: Update order status based on payment result
- 4.15.3: Configure webhook endpoint in Stripe dashboard
- 4.15.4: Add webhook secret to User Secrets
- 4.15.5: Test webhook handling

### Task 4.16: Create Payment Retry Logic
- 4.16.1: Detect failed payments in checkout
- 4.16.2: Show payment failure message
- 4.16.3: Allow customer to retry payment
- 4.16.4: Provide option to use different payment method
- 4.16.5: Log payment failures
- 4.16.6: Send failure notification email

### Task 4.17: Implement Refund Processing
- 4.17.1: Create ProcessRefundCommand
- 4.17.2: Create ProcessRefundHandler
- 4.17.3: Call payment service RefundPaymentAsync
- 4.17.4: Update payment status to Refunded
- 4.17.5: Update order status
- 4.17.6: Create refund record in database
- 4.17.7: Send refund confirmation email
- 4.17.8: Add refund notes

---

## PHASE 5: ORDER MANAGEMENT (Weeks 11-12)

### Task 5.1: Create Order Application Layer
- 5.1.1: Create OrderDto class (if not done earlier)
- 5.1.2: Create OrderDetailDto class
- 5.1.3: Create OrderListDto class
- 5.1.4: Create GetOrderByIdQuery class
- 5.1.5: Create GetOrdersByCustomerQuery class
- 5.1.6: Create GetAllOrdersQuery class
- 5.1.7: Create UpdateOrderStatusCommand class
- 5.1.8: Create CancelOrderCommand class
- 5.1.9: Create corresponding handlers
- 5.1.10: Create IOrderService interface (if not done earlier)
- 5.1.11: Update OrderService implementation

### Task 5.2: Create Customer Order History Page
- 5.2.1: Create Account/Orders folder
- 5.2.2: Create Account/Orders/Index.cshtml
- 5.2.3: Create Account/Orders/Index.cshtml.cs
  - 5.2.3.1: Inject IOrderService
  - 5.2.3.2: Load customer orders in OnGetAsync
  - 5.2.3.3: Add pagination
  - 5.2.3.4: Add filtering by status
  - 5.2.3.5: Add date range filter
- 5.2.4: Display orders in table format
- 5.2.5: Show order number, date, status, total
- 5.2.6: Add "View Details" link for each order
- 5.2.7: Add "Track Shipment" link for shipped orders

### Task 5.3: Create Customer Order Detail Page
- 5.3.1: Create Account/Orders/Details.cshtml
- 5.3.2: Create Account/Orders/Details.cshtml.cs
  - 5.3.2.1: Load order details in OnGetAsync
  - 5.3.2.2: Verify order belongs to current customer
  - 5.3.2.3: Load order items
  - 5.3.2.4: Load addresses
  - 5.3.2.5: Load payment info
  - 5.3.2.6: Load shipment info
- 5.3.3: Display order summary
- 5.3.4: Show order items with images
- 5.3.5: Display shipping and billing addresses
- 5.3.6: Show payment information (masked)
- 5.3.7: Display order status timeline
- 5.3.8: Add tracking information if available
- 5.3.9: Add "Cancel Order" button (if eligible)
- 5.3.10: Add "Request Return" button (if eligible)

### Task 5.4: Create Order Tracking Page
- 5.4.1: Create Account/Orders/Track.cshtml
- 5.4.2: Create Account/Orders/Track.cshtml.cs
  - 5.4.2.1: Inject IShippingService
  - 5.4.2.2: Get tracking number from order
  - 5.4.2.3: Call TrackShipmentAsync in OnGetAsync
  - 5.4.2.4: Display tracking events
- 5.4.3: Show shipment status
- 5.4.4: Display tracking history timeline
- 5.4.5: Show estimated delivery date
- 5.4.6: Add link to carrier tracking page

### Task 5.5: Create Admin Order Dashboard
- 5.5.1: Create Admin/Orders folder
- 5.5.2: Create Admin/Orders/Index.cshtml
- 5.5.3: Create Admin/Orders/Index.cshtml.cs
  - 5.5.3.1: Add [Authorize(Roles = "Admin,Manager,Staff")] attribute
  - 5.5.3.2: Load all orders with pagination
  - 5.5.3.3: Add status filter
  - 5.5.3.4: Add date range filter
  - 5.5.3.5: Add customer search
  - 5.5.3.6: Add sorting options
- 5.5.4: Display orders in grid format
- 5.5.5: Show order number, customer, date, status, total
- 5.5.6: Add status badges with colors
- 5.5.7: Add "View Details" action
- 5.5.8: Add "Process" action for pending orders
- 5.5.9: Add quick status update dropdown

### Task 5.6: Create Admin Order Detail Page
- 5.6.1: Create Admin/Orders/Details.cshtml
- 5.6.2: Create Admin/Orders/Details.cshtml.cs
  - 5.6.2.1: Load complete order information
  - 5.6.2.2: Load customer information
  - 5.6.2.3: Load all related entities
- 5.6.3: Display comprehensive order information
- 5.6.4: Show customer contact details
- 5.6.5: Display order items with SKUs
- 5.6.6: Show payment details
- 5.6.7: Display shipping information
- 5.6.8: Add status update section
- 5.6.9: Add internal notes section
- 5.6.10: Add order timeline/audit log
- 5.6.11: Add action buttons (Process, Ship, Cancel)

### Task 5.7: Create Pick List Generation
- 5.7.1: Create GeneratePickListCommand
- 5.7.2: Create GeneratePickListHandler
- 5.7.3: Query order items with warehouse locations
- 5.7.4: Group items by warehouse location
- 5.7.5: Create Admin/Orders/PickList.cshtml
- 5.7.6: Create Admin/Orders/PickList.cshtml.cs
- 5.7.7: Display items grouped by location
- 5.7.8: Show product images and SKUs
- 5.7.9: Add checkboxes for picked items
- 5.7.10: Add print functionality
- 5.7.11: Add "Mark as Picked" button

### Task 5.8: Create Packing Slip Generation
- 5.8.1: Create GeneratePackingSlipCommand
- 5.8.2: Create GeneratePackingSlipHandler
- 5.8.3: Create Admin/Orders/PackingSlip.cshtml
- 5.8.4: Create Admin/Orders/PackingSlip.cshtml.cs
- 5.8.5: Display order summary
- 5.8.6: Show items with quantities
- 5.8.7: Display shipping address
- 5.8.8: Add barcode for order number
- 5.8.9: Add print functionality
- 5.8.10: Make printer-friendly layout

### Task 5.9: Implement Order Processing Workflow
- 5.9.1: Create ProcessOrderCommand
- 5.9.2: Create ProcessOrderHandler
  - 5.9.2.1: Validate order can be processed
  - 5.9.2.2: Reserve inventory
  - 5.9.2.3: Update order status to "Processing"
  - 5.9.2.4: Generate pick list
  - 5.9.2.5: Send processing notification email
- 5.9.3: Add "Start Processing" button in admin order detail
- 5.9.4: Implement OnPostStartProcessingAsync
- 5.9.5: Show success message
- 5.9.6: Redirect to pick list

### Task 5.10: Implement Shipping Label Generation
- 5.10.1: Create GenerateShippingLabelCommand
- 5.10.2: Create GenerateShippingLabelHandler
  - 5.10.2.1: Get order details and shipping address
  - 5.10.2.2: Calculate package weight
  - 5.10.2.3: Call IShippingService.CreateShipmentAsync
  - 5.10.2.4: Call IShippingService.GenerateLabelAsync
  - 5.10.2.5: Save shipment details
  - 5.10.2.6: Save tracking number
  - 5.10.2.7: Save label URL
  - 5.10.2.8: Update order status to "Shipped"
- 5.10.3: Add "Generate Label" section in admin order detail
- 5.10.4: Allow selection of shipping carrier and method
- 5.10.5: Add package weight input
- 5.10.6: Implement OnPostGenerateLabelAsync
- 5.10.7: Display generated label URL
- 5.10.8: Add "Download Label" button
- 5.10.9: Add "Print Label" button

### Task 5.11: Implement Order Shipment
- 5.11.1: Create ShipOrderCommand
- 5.11.2: Create ShipOrderHandler
  - 5.11.2.1: Validate label has been generated
  - 5.11.2.2: Update order status to "Shipped"
  - 5.11.2.3: Set shipment date
  - 5.11.2.4: Decrement inventory quantities
  - 5.11.2.5: Release inventory reservations
  - 5.11.2.6: Send shipment notification email
- 5.11.3: Add "Mark as Shipped" button
- 5.11.4: Implement OnPostMarkShippedAsync
- 5.11.5: Show confirmation message

### Task 5.12: Implement Order Cancellation
- 5.12.1: Create CancelOrderCommand (if not done earlier)
- 5.12.2: Create CancelOrderHandler
  - 5.12.2.1: Validate order can be cancelled
  - 5.12.2.2: Process refund if payment captured
  - 5.12.2.3: Release inventory reservations
  - 5.12.2.4: Update order status to "Cancelled"
  - 5.12.2.5: Add cancellation reason
  - 5.12.2.6: Send cancellation email
- 5.12.3: Add "Cancel Order" button in customer order detail
- 5.12.4: Add "Cancel Order" button in admin order detail
- 5.12.5: Add cancellation reason dropdown/textarea
- 5.12.6: Implement OnPostCancelAsync
- 5.12.7: Show confirmation dialog
- 5.12.8: Display cancellation success message

### Task 5.13: Create Order Status Update Workflow
- 5.13.1: Create UpdateOrderStatusCommand (if not done earlier)
- 5.13.2: Create UpdateOrderStatusHandler
  - 5.13.2.1: Validate status transition is allowed
  - 5.13.2.2: Update order status
  - 5.13.2.3: Create status history record
  - 5.13.2.4: Send appropriate notification email
- 5.13.3: Add status dropdown in admin order detail
- 5.13.4: Implement OnPostUpdateStatusAsync
- 5.13.5: Add validation for invalid status transitions

### Task 5.14: Create Order Status History
- 5.14.1: Create OrderStatusHistory entity
- 5.14.2: Create entity configuration
- 5.14.3: Add migration
- 5.14.4: Record status changes automatically
- 5.14.5: Display status history in admin order detail
- 5.14.6: Show timestamp and user who made change
- 5.14.7: Add status change notes

### Task 5.15: Create Order Search Functionality
- 5.15.1: Add search bar in admin orders index
- 5.15.2: Search by order number
- 5.15.3: Search by customer name
- 5.15.4: Search by customer email
- 5.15.5: Search by product name/SKU
- 5.15.6: Implement full-text search in database
- 5.15.7: Add search indexing

### Task 5.16: Create Order Email Notifications
- 5.16.1: Create IEmailService interface (if not done)
- 5.16.2: Create EmailService implementation
  - 5.16.2.1: Configure SendGrid or SMTP
  - 5.16.2.2: Implement SendEmailAsync method
- 5.16.3: Create email templates folder
- 5.16.4: Create order confirmation email template
- 5.16.5: Create order processing email template
- 5.16.6: Create order shipped email template
- 5.16.7: Create order delivered email template
- 5.16.8: Create order cancelled email template
- 5.16.9: Send appropriate emails on status changes
- 5.16.10: Include order details and tracking in emails

### Task 5.17: Implement Order Notes
- 5.17.1: Add Notes field to Order entity (if not done)
- 5.17.2: Add internal notes section in admin order detail
- 5.17.3: Allow staff to add notes
- 5.17.4: Display notes history with timestamps
- 5.17.5: Show user who added each note

---

## PHASE 6: INVENTORY & REPORTING (Weeks 13-14)

### Task 6.1: Create Inventory Application Layer
- 6.1.1: Create InventoryDto class
- 6.1.2: Create InventoryTransactionDto class
- 6.1.3: Create GetInventoryByProductQuery class
- 6.1.4: Create GetLowStockProductsQuery class
- 6.1.5: Create AdjustInventoryCommand class
- 6.1.6: Create ReserveInventoryCommand class
- 6.1.7: Create ReleaseInventoryCommand class
- 6.1.8: Create corresponding handlers
- 6.1.9: Create IInventoryService interface
- 6.1.10: Create InventoryService implementation

### Task 6.2: Create Inventory Repository Methods
- 6.2.1: Update IInventoryRepository interface
  - 6.2.1.1: Add GetByProductIdAsync method
  - 6.2.1.2: Add GetLowStockItemsAsync method
  - 6.2.1.3: Add AdjustStockAsync method
  - 6.2.1.4: Add ReserveStockAsync method
  - 6.2.1.5: Add ReleaseStockAsync method
- 6.2.2: Implement methods in InventoryRepository

### Task 6.3: Create Inventory Dashboard
- 6.3.1: Create Admin/Inventory folder
- 6.3.2: Create Admin/Inventory/Index.cshtml
- 6.3.3: Create Admin/Inventory/Index.cshtml.cs
  - 6.3.3.1: Add [Authorize(Roles = "Admin,Manager,Staff")] attribute
  - 6.3.3.2: Load all inventory items with products
  - 6.3.3.3: Add search and filtering
  - 6.3.3.4: Add low stock filter
  - 6.3.3.5: Add sorting options
- 6.3.4: Display inventory grid
- 6.3.5: Show product name, SKU, quantity on hand, reserved, available
- 6.3.6: Highlight low stock items in red
- 6.3.7: Add "Adjust Stock" action
- 6.3.8: Add "View History" action

### Task 6.4: Create Inventory Adjustment Page
- 6.4.1: Create Admin/Inventory/Adjust.cshtml
- 6.4.2: Create Admin/Inventory/Adjust.cshtml.cs
  - 6.4.2.1: Load product and current inventory
  - 6.4.2.2: Show current stock levels
  - 6.4.2.3: Add adjustment type dropdown (Add, Remove, Set)
  - 6.4.2.4: Add quantity input
  - 6.4.2.5: Add reason textarea
  - 6.4.2.6: Implement OnPostAsync
- 6.4.3: Validate adjustment quantity
- 6.4.4: Create inventory transaction record
- 6.4.5: Update inventory quantities
- 6.4.6: Show success message
- 6.4.7: Redirect to inventory index

### Task 6.5: Create Inventory Transaction History
- 6.5.1: Create InventoryTransaction entity (if not done in Phase 1)
- 6.5.2: Create entity configuration
- 6.5.3: Add migration
- 6.5.4: Record all inventory changes
- 6.5.5: Create Admin/Inventory/History.cshtml
- 6.5.6: Create Admin/Inventory/History.cshtml.cs
  - 6.5.6.1: Load transactions for product
  - 6.5.6.2: Add date range filter
  - 6.5.6.3: Add transaction type filter
  - 6.5.6.4: Add pagination
- 6.5.7: Display transaction log
- 6.5.8: Show date, type, quantity change, reason, user
- 6.5.9: Add export functionality

### Task 6.6: Implement Low Stock Alerts
- 6.6.1: Create CheckLowStockCommand
- 6.6.2: Create CheckLowStockHandler
  - 6.6.2.1: Query products below reorder point
  - 6.6.2.2: Generate alert notifications
  - 6.6.2.3: Send email to purchasing team
- 6.6.3: Create scheduled background job (Hangfire)
- 6.6.4: Run low stock check daily
- 6.6.5: Create Admin/Inventory/LowStock.cshtml
- 6.6.6: Display low stock items
- 6.6.7: Add "Create Purchase Order" action

### Task 6.7: Create Supplier Management
- 6.7.1: Create Supplier entity (if not done in Phase 1)
- 6.7.2: Create entity configuration
- 6.7.3: Add migration
- 6.7.4: Create SupplierDto class
- 6.7.5: Create supplier CRUD commands and queries
- 6.7.6: Create Admin/Suppliers folder
- 6.7.7: Create Admin/Suppliers/Index.cshtml
- 6.7.8: Create Admin/Suppliers/Create.cshtml
- 6.7.9: Create Admin/Suppliers/Edit.cshtml
- 6.7.10: Create Admin/Suppliers/Delete.cshtml
- 6.7.11: Implement corresponding PageModels

### Task 6.8: Create Purchase Order Management
- 6.8.1: Create PurchaseOrder entity (if not done in Phase 1)
- 6.8.2: Create PurchaseOrderItem entity
- 6.8.3: Create entity configurations
- 6.8.4: Add migrations
- 6.8.5: Create PurchaseOrderDto class
- 6.8.6: Create purchase order commands and queries
- 6.8.7: Create Admin/PurchaseOrders folder
- 6.8.8: Create Admin/PurchaseOrders/Index.cshtml
- 6.8.9: Create Admin/PurchaseOrders/Create.cshtml
  - 6.8.9.1: Select supplier
  - 6.8.9.2: Add products with quantities
  - 6.8.9.3: Set expected delivery date
  - 6.8.9.4: Calculate total cost
- 6.8.10: Create Admin/PurchaseOrders/Details.cshtml
- 6.8.11: Create Admin/PurchaseOrders/Receive.cshtml
  - 6.8.11.1: Mark items as received
  - 6.8.11.2: Update inventory automatically
  - 6.8.11.3: Update PO status to completed

### Task 6.9: Create Sales Reports
- 6.9.1: Create Reports folder in Application
- 6.9.2: Create SalesReportDto class
- 6.9.3: Create GenerateSalesReportQuery class
  - 6.9.3.1: Add date range parameters
  - 6.9.3.2: Add grouping options (daily, weekly, monthly)
- 6.9.4: Create GenerateSalesReportHandler
  - 6.9.4.1: Query orders in date range
  - 6.9.4.2: Calculate total sales
  - 6.9.4.3: Calculate total orders
  - 6.9.4.4: Calculate average order value
  - 6.9.4.5: Group by time period
- 6.9.5: Create Admin/Reports folder
- 6.9.6: Create Admin/Reports/Sales.cshtml
- 6.9.7: Create Admin/Reports/Sales.cshtml.cs
  - 6.9.7.1: Add date range picker
  - 6.9.7.2: Add grouping selector
  - 6.9.7.3: Generate report on form submit
- 6.9.8: Display report data in tables
- 6.9.9: Add Chart.js visualizations
- 6.9.10: Add export to Excel functionality
- 6.9.11: Add export to PDF functionality

### Task 6.10: Create Inventory Reports
- 6.10.1: Create InventoryReportDto class
- 6.10.2: Create GenerateInventoryReportQuery class
- 6.10.3: Create GenerateInventoryReportHandler
  - 6.10.3.1: Calculate total inventory value
  - 6.10.3.2: List low stock items
  - 6.10.3.3: Calculate inventory turnover
  - 6.10.3.4: Identify slow-moving items
- 6.10.4: Create Admin/Reports/Inventory.cshtml
- 6.10.5: Create Admin/Reports/Inventory.cshtml.cs
- 6.10.6: Display inventory metrics
- 6.10.7: Show valuation report
- 6.10.8: Display stock movement analysis
- 6.10.9: Add export functionality

### Task 6.11: Create Product Performance Report
- 6.11.1: Create ProductPerformanceDto class
- 6.11.2: Create GenerateProductPerformanceQuery class
- 6.11.3: Create GenerateProductPerformanceHandler
  - 6.11.3.1: Calculate top-selling products
  - 6.11.3.2: Calculate revenue by product
  - 6.11.3.3: Calculate profit margins
  - 6.11.3.4: Identify underperforming products
- 6.11.4: Create Admin/Reports/Products.cshtml
- 6.11.5: Display top sellers
- 6.11.6: Show revenue breakdown by category
- 6.11.7: Display profit margin analysis
- 6.11.8: Add visualizations

### Task 6.12: Create Customer Analytics
- 6.12.1: Create CustomerAnalyticsDto class
- 6.12.2: Create GenerateCustomerAnalyticsQuery class
- 6.12.3: Create GenerateCustomerAnalyticsHandler
  - 6.12.3.1: Calculate total customers
  - 6.12.3.2: Calculate new customers in period
  - 6.12.3.3: Calculate repeat customer rate
  - 6.12.3.4: Calculate customer lifetime value
  - 6.12.3.5: Identify top customers
- 6.12.4: Create Admin/Reports/Customers.cshtml
- 6.12.5: Display customer metrics
- 6.12.6: Show top customers by revenue
- 6.12.7: Display customer acquisition trends
- 6.12.8: Add cohort analysis

### Task 6.13: Implement Report Export Functionality
- 6.13.1: Install EPPlus NuGet package for Excel
- 6.13.2: Create IExportService interface
  - 6.13.2.1: Define ExportToExcelAsync method
  - 6.13.2.2: Define ExportToPdfAsync method
- 6.13.3: Create ExportService implementation
  - 6.13.3.1: Implement Excel export using EPPlus
  - 6.13.3.2: Format Excel sheets with headers
  - 6.13.3.3: Add styling to Excel exports
- 6.13.4: Add "Export to Excel" button to all reports
- 6.13.5: Implement OnPostExportAsync in report pages
- 6.13.6: Return file download result

### Task 6.14: Create Report Dashboard
- 6.14.1: Create Admin/Reports/Index.cshtml
- 6.14.2: Create Admin/Reports/Index.cshtml.cs
  - 6.14.2.1: Load key metrics
  - 6.14.2.2: Calculate today's sales
  - 6.14.2.3: Calculate month-to-date sales
  - 6.14.2.4: Get pending orders count
  - 6.14.4.5: Get low stock items count
- 6.14.3: Display KPI cards
- 6.14.4: Add quick stats widgets
- 6.14.5: Show recent orders table
- 6.14.6: Display sales chart (last 30 days)
- 6.14.7: Add links to detailed reports

### Task 6.15: Implement Scheduled Reports
- 6.15.1: Install Hangfire NuGet package
- 6.15.2: Configure Hangfire in Program.cs
- 6.15.3: Create scheduled job for daily sales report
- 6.15.4: Create scheduled job for weekly inventory report
- 6.15.5: Create scheduled job for monthly performance report
- 6.15.6: Email reports to management
- 6.15.7: Add Hangfire dashboard for job monitoring

---

## PHASE 7: POLISH & OPTIMIZATION (Weeks 15-16)

### Task 7.1: Create Product Reviews
- 7.1.1: Create ProductReview entity (if not done in Phase 1)
- 7.1.2: Create entity configuration
- 7.1.3: Add migration
- 7.1.4: Create ReviewDto class
- 7.1.5: Create CreateReviewCommand class
- 7.1.6: Create GetReviewsByProductQuery class
- 7.1.7: Create corresponding handlers
- 7.1.8: Create IReviewService interface
- 7.1.9: Create ReviewService implementation
- 7.1.10: Add review section to product detail page
- 7.1.11: Display existing reviews
- 7.1.12: Add "Write Review" button (for verified purchases)
- 7.1.13: Create review form modal
- 7.1.14: Implement rating stars (1-5)
- 7.1.15: Add review submission
- 7.1.16: Implement review approval workflow
- 7.1.17: Create Admin/Reviews page for moderation

### Task 7.2: Create Wishlist Feature
- 7.2.1: Create Wishlist entity (if not done in Phase 1)
- 7.2.2: Create entity configuration
- 7.2.3: Add migration
- 7.2.4: Create WishlistDto class
- 7.2.5: Create AddToWishlistCommand class
- 7.2.6: Create RemoveFromWishlistCommand class
- 7.2.7: Create GetWishlistQuery class
- 7.2.8: Create corresponding handlers
- 7.2.9: Create IWishlistService interface
- 7.2.10: Create WishlistService implementation
- 7.2.11: Add heart icon to product cards
- 7.2.12: Implement add/remove wishlist functionality
- 7.2.13: Create Account/Wishlist page
- 7.2.14: Display wishlist items
- 7.2.15: Add "Move to Cart" functionality
- 7.2.16: Add remove from wishlist button

### Task 7.3: Implement Discount Codes/Coupons
- 7.3.1: Create Coupon entity
- 7.3.2: Create entity configuration
- 7.3.3: Add migration
- 7.3.4: Create CouponDto class
- 7.3.5: Create ValidateCouponCommand class
- 7.3.6: Create ApplyCouponCommand class
- 7.3.7: Create corresponding handlers
- 7.3.8: Create Admin/Coupons management pages
- 7.3.9: Add coupon code input to checkout
- 7.3.10: Validate coupon on form submit
- 7.3.11: Apply discount to order total
- 7.3.12: Display discount in order summary
- 7.3.13: Prevent coupon reuse
- 7.3.14: Track coupon usage

### Task 7.4: Implement Caching
- 7.4.1: Install Microsoft.Extensions.Caching.Memory
- 7.4.2: Configure memory cache in Program.cs
- 7.4.3: Create CacheService wrapper
- 7.4.4: Cache category list
- 7.4.5: Cache brand list
- 7.4.6: Cache featured products
- 7.4.7: Cache product details (with expiration)
- 7.4.8: Implement cache invalidation on updates
- 7.4.9: Add cache-aside pattern in services
- 7.4.10: Optional: Install Redis for distributed caching
- 7.4.11: Optional: Configure Redis connection
- 7.4.12: Optional: Use Redis for session state

### Task 7.5: Optimize Database Queries
- 7.5.1: Review all queries for N+1 issues
- 7.5.2: Add .Include() for eager loading where needed
- 7.5.3: Use .AsNoTracking() for read-only queries
- 7.5.4: Add .Select() projections to reduce data transfer
- 7.5.5: Review and optimize slow queries
- 7.5.6: Add missing database indexes
- 7.5.7: Create composite indexes for common filters
- 7.5.8: Analyze query execution plans
- 7.5.9: Optimize complex report queries
- 7.5.10: Consider materialized views for reports

### Task 7.6: Implement Response Caching
- 7.6.1: Add response caching middleware
- 7.6.2: Configure cache profiles in Program.cs
- 7.6.3: Add [ResponseCache] attribute to appropriate pages
- 7.6.4: Cache product listing pages
- 7.6.5: Cache product detail pages
- 7.6.6: Cache category pages
- 7.6.7: Set appropriate cache durations
- 7.6.8: Add cache-control headers

### Task 7.7: Optimize Frontend Performance
- 7.7.1: Minify and bundle CSS files
- 7.7.2: Minify and bundle JavaScript files
- 7.7.3: Enable Gzip/Brotli compression
- 7.7.4: Implement lazy loading for images
- 7.7.5: Optimize image sizes
- 7.7.6: Use responsive images (srcset)
- 7.7.7: Add CDN for static assets
- 7.7.8: Implement browser caching headers
- 7.7.9: Reduce HTTP requests
- 7.7.10: Defer non-critical JavaScript

### Task 7.8: Implement Logging
- 7.8.1: Configure Serilog (already installed in Phase 1)
- 7.8.2: Add file sink for persistent logs
- 7.8.3: Add structured logging throughout application
- 7.8.4: Log all exceptions
- 7.8.5: Log important business events
- 7.8.6: Log performance metrics
- 7.8.7: Add correlation IDs for request tracking
- 7.8.8: Configure log levels per environment
- 7.8.9: Add log filtering
- 7.8.10: Optional: Integrate with Application Insights

### Task 7.9: Implement Error Handling
- 7.9.1: Create global exception handler middleware
- 7.9.2: Create custom error pages (404, 500)
- 7.9.3: Handle validation errors gracefully
- 7.9.4: Display user-friendly error messages
- 7.9.5: Log detailed error information
- 7.9.6: Implement retry logic for transient failures
- 7.9.7: Add circuit breaker for external services
- 7.9.8: Create error notification system
- 7.9.9: Monitor error rates

### Task 7.10: Implement Security Enhancements
- 7.10.1: Enable HTTPS redirection
- 7.10.2: Configure HSTS headers
- 7.10.3: Add anti-forgery tokens to all forms
- 7.10.4: Implement CSRF protection
- 7.10.5: Add XSS protection headers
- 7.10.6: Implement content security policy
- 7.10.7: Sanitize user inputs
- 7.10.8: Implement rate limiting
- 7.10.9: Add request size limits
- 7.10.10: Implement account lockout
- 7.10.11: Add two-factor authentication
- 7.10.12: Implement password complexity requirements
- 7.10.13: Add security headers middleware
- 7.10.14: Encrypt sensitive configuration

### Task 7.11: Create Unit Tests
- 7.11.1: Create TechMart.UnitTests project
- 7.11.2: Install xUnit and Moq NuGet packages
- 7.11.3: Create tests for domain entities
- 7.11.4: Create tests for value objects
- 7.11.5: Create tests for domain services
- 7.11.6: Create tests for command handlers
- 7.11.7: Create tests for query handlers
- 7.11.8: Create tests for application services
- 7.11.9: Aim for >80% code coverage
- 7.11.10: Run tests in CI pipeline

### Task 7.12: Create Integration Tests
- 7.12.1: Create TechMart.IntegrationTests project
- 7.12.2: Install necessary testing packages
- 7.12.3: Set up in-memory database for testing
- 7.12.4: Create tests for repositories
- 7.12.5: Create tests for database operations
- 7.12.6: Create tests for API endpoints (if applicable)
- 7.12.7: Test complete workflows (order placement, etc.)
- 7.12.8: Test payment integration (with test mode)
- 7.12.9: Test email sending

### Task 7.13: Create Functional/E2E Tests
- 7.13.1: Create TechMart.FunctionalTests project
- 7.13.2: Install Selenium or Playwright
- 7.13.3: Create tests for user registration and login
- 7.13.4: Create tests for product browsing
- 7.13.5: Create tests for add to cart
- 7.13.6: Create tests for checkout flow
- 7.13.7: Create tests for order placement
- 7.13.8: Create tests for admin workflows
- 7.13.9: Run tests against staging environment

### Task 7.14: Performance Testing
- 7.14.1: Install load testing tool (k6, JMeter, or Artillery)
- 7.14.2: Create load test scripts
- 7.14.3: Test homepage performance
- 7.14.4: Test product listing performance
- 7.14.5: Test checkout performance
- 7.14.6: Test database under load
- 7.14.7: Identify bottlenecks
- 7.14.8: Optimize slow operations
- 7.14.9: Test concurrent user scenarios
- 7.14.10: Document performance benchmarks

### Task 7.15: Create Documentation
- 7.15.1: Document API endpoints (if applicable)
- 7.15.2: Create architecture documentation
- 7.15.3: Document database schema
- 7.15.4: Create deployment guide
- 7.15.5: Write developer onboarding guide
- 7.15.6: Document coding standards
- 7.15.7: Create troubleshooting guide
- 7.15.8: Document configuration settings
- 7.15.9: Create user manual
- 7.15.10: Document admin workflows

### Task 7.16: Accessibility Improvements
- 7.16.1: Add ARIA labels to interactive elements
- 7.16.2: Ensure proper heading hierarchy
- 7.16.3: Add alt text to all images
- 7.16.4: Ensure keyboard navigation works
- 7.16.5: Add focus indicators
- 7.16.6: Ensure sufficient color contrast
- 7.16.7: Test with screen readers
- 7.16.8: Add skip navigation links
- 7.16.9: Ensure form labels are properly associated
- 7.16.10: Run accessibility audit (Lighthouse, axe)

### Task 7.17: Mobile Responsiveness
- 7.17.1: Test all pages on mobile devices
- 7.17.2: Optimize touch targets for mobile
- 7.17.3: Ensure readable font sizes on mobile
- 7.17.4: Test checkout flow on mobile
- 7.17.5: Optimize images for mobile bandwidth
- 7.17.6: Test with various screen sizes
- 7.17.7: Ensure tables are mobile-friendly
- 7.17.8: Test forms on mobile devices
- 7.17.9: Optimize navigation for mobile
- 7.17.10: Add mobile-specific features if needed

### Task 7.18: SEO Optimization
- 7.18.1: Add meta titles to all pages
- 7.18.2: Add meta descriptions to all pages
- 7.18.3: Implement Open Graph tags
- 7.18.4: Add Twitter Card tags
- 7.18.5: Create XML sitemap
- 7.18.6: Add robots.txt
- 7.18.7: Implement canonical URLs
- 7.18.8: Add structured data (Schema.org)
- 7.18.9: Optimize URLs for SEO
- 7.18.10: Create 301 redirects for old URLs

### Task 7.19: Final UAT and Bug Fixes
- 7.19.1: Conduct user acceptance testing
- 7.19.2: Create UAT test cases
- 7.19.3: Gather feedback from stakeholders
- 7.19.4: Create bug tracking list
- 7.19.5: Prioritize bugs (critical, high, medium, low)
- 7.19.6: Fix critical bugs
- 7.19.7: Fix high-priority bugs
- 7.19.8: Address medium-priority bugs
- 7.19.9: Retest fixed issues
- 7.19.10: Sign-off from stakeholders

### Task 7.20: Deployment Preparation
- 7.20.1: Choose hosting platform (Azure, AWS, or on-premises)
- 7.20.2: Set up production database
- 7.20.3: Configure production connection strings
- 7.20.4: Set up production API keys (Stripe, Shippo, etc.)
- 7.20.5: Configure SSL certificates
- 7.20.6: Set up CDN for static assets
- 7.20.7: Configure email service for production
- 7.20.8: Set up backup strategy
- 7.20.9: Configure monitoring and alerting
- 7.20.10: Create deployment checklist
- 7.20.11: Plan rollback strategy
- 7.20.12: Deploy to staging environment
- 7.20.13: Final staging tests
- 7.20.14: Deploy to production
- 7.20.15: Smoke test production
- 7.20.16: Monitor post-deployment

---

## POST-LAUNCH TASKS

### Task 8.1: Monitoring and Maintenance
- 8.1.1: Set up application monitoring
- 8.1.2: Monitor error logs daily
- 8.1.3: Monitor performance metrics
- 8.1.4: Review user feedback
- 8.1.5: Monitor payment success rates
- 8.1.6: Monitor order fulfillment metrics
- 8.1.7: Track inventory turnover
- 8.1.8: Review security logs
- 8.1.9: Perform regular backups
- 8.1.10: Plan for scaling

### Task 8.2: Continuous Improvement
- 8.2.1: Analyze user behavior data
- 8.2.2: Identify conversion bottlenecks
- 8.2.3: A/B test key pages
- 8.2.4: Optimize based on metrics
- 8.2.5: Gather customer feedback
- 8.2.6: Plan feature enhancements
- 8.2.7: Update documentation
- 8.2.8: Keep dependencies updated
- 8.2.9: Address technical debt
- 8.2.10: Plan for v2.0 features
