using System.Linq;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using TechMart.Domain.Entities;
using TechMart.Infrastructure.Data;
using TechMart.Infrastructure.Identity;

namespace TechMart.Infrastructure.Data;

public static class DbInitializer
{
    public static async Task InitializeAsync(IServiceProvider serviceProvider)
    {
        using var scope = serviceProvider.CreateScope();
        var logger = scope.ServiceProvider.GetRequiredService<ILoggerFactory>().CreateLogger("DbInitializer");

        try
        {
            var context = scope.ServiceProvider.GetRequiredService<TechMartDbContext>();

            if ((await context.Database.GetPendingMigrationsAsync()).Any())
                await context.Database.MigrateAsync();

            var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();

            await SeedRolesAsync(roleManager);
            await SeedAdminUserAsync(userManager);
            await SeedCatalogDataAsync(context);

            logger.LogInformation("Database initialized successfully.");
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "An error occurred while initializing the database.");
            throw;
        }
    }

    private static async Task SeedRolesAsync(RoleManager<IdentityRole> roleManager)
    {
        var roles = new[] { "Customer", "Staff", "Manager", "Admin" };

        foreach (var role in roles)
        {
            if (!await roleManager.RoleExistsAsync(role))
            {
                await roleManager.CreateAsync(new IdentityRole(role));
            }
        }
    }

    private static async Task SeedAdminUserAsync(UserManager<ApplicationUser> userManager)
    {
        const string adminEmail = "admin@techmart.com";
        const string adminPassword = "Admin@123";

        var existingAdmin = await userManager.FindByEmailAsync(adminEmail);
        if (existingAdmin != null)
            return;

        var admin = new ApplicationUser
        {
            UserName = adminEmail,
            Email = adminEmail,
            EmailConfirmed = true,
            FirstName = "Admin",
            LastName = "User",
            RegistrationDate = DateTime.UtcNow
        };

        var result = await userManager.CreateAsync(admin, adminPassword);
        if (result.Succeeded)
        {
            await userManager.AddToRoleAsync(admin, "Admin");
        }
    }

    private static async Task SeedCatalogDataAsync(TechMartDbContext context)
    {
        if (await context.Categories.AnyAsync())
            return;

        var categories = new[]
        {
            new Category { Name = "Electronics", Description = "Electronic devices and gadgets", DisplayOrder = 1, IsActive = true },
            new Category { Name = "Clothing", Description = "Apparel and fashion", DisplayOrder = 2, IsActive = true },
            new Category { Name = "Home & Garden", Description = "Home and garden supplies", DisplayOrder = 3, IsActive = true }
        };
        context.Categories.AddRange(categories);

        var brands = new[]
        {
            new Brand { Name = "TechPro", Description = "Professional technology products", LogoUrl = null },
            new Brand { Name = "FashionFirst", Description = "Trendy fashion brand", LogoUrl = null },
            new Brand { Name = "HomeStyle", Description = "Quality home products", LogoUrl = null }
        };
        context.Brands.AddRange(brands);

        await context.SaveChangesAsync();

        var electronicsCategory = await context.Categories.FirstAsync(c => c.Name == "Electronics");
        var techProBrand = await context.Brands.FirstAsync(b => b.Name == "TechPro");

        var products = new[]
        {
            new Product
            {
                SKU = "TP-001",
                Name = "Wireless Mouse",
                Description = "Ergonomic wireless mouse with long battery life",
                CategoryId = electronicsCategory.Id,
                BrandId = techProBrand.Id,
                Price = 29.99m,
                CostPrice = 15.00m,
                IsActive = true,
                IsFeatured = true
            },
            new Product
            {
                SKU = "TP-002",
                Name = "USB-C Hub",
                Description = "7-in-1 USB-C hub with HDMI and SD card reader",
                CategoryId = electronicsCategory.Id,
                BrandId = techProBrand.Id,
                Price = 49.99m,
                CostPrice = 25.00m,
                IsActive = true,
                IsFeatured = false
            }
        };

        context.Products.AddRange(products);
        await context.SaveChangesAsync();

        foreach (var product in products)
        {
            context.Inventories.Add(new Inventory
            {
                ProductId = product.Id,
                QuantityOnHand = 100,
                QuantityReserved = 0,
                ReorderPoint = 10,
                ReorderQuantity = 50,
                WarehouseLocation = "A-01"
            });
        }

        await context.SaveChangesAsync();
    }
}
