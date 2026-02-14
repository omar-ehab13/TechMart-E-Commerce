using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TechMart.Domain.Entities;
using TechMart.Domain.Interfaces;
using TechMart.Infrastructure.Data;
using TechMart.Infrastructure.Identity;
using TechMart.Infrastructure.Repositories;

namespace TechMart.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<TechMartDbContext>(options =>
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            options.UseSqlServer(connectionString);
        });

        services.AddIdentityCore<ApplicationUser>(options =>
        {
            IdentityConfiguration.Configure(options);
        })
        .AddRoles<IdentityRole>()
        .AddEntityFrameworkStores<TechMartDbContext>();

        services.AddScoped<IUnitOfWork, UnitOfWork>();

        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<IRepository<Product>, ProductRepository>();

        services.AddScoped<IOrderRepository, OrderRepository>();
        services.AddScoped<IRepository<Order>, OrderRepository>();

        services.AddScoped<IInventoryRepository, InventoryRepository>();
        services.AddScoped<IRepository<Inventory>, InventoryRepository>();

        services.AddScoped<IAddressRepository, AddressRepository>();
        services.AddScoped<IRepository<Address>, AddressRepository>();

        services.AddScoped<IRepository<Category>, GenericRepository<Category>>();
        services.AddScoped<IRepository<Brand>, GenericRepository<Brand>>();
        services.AddScoped<ICartRepository, CartRepository>();
        services.AddScoped<IApplicationUserRepository, ApplicationUserRepository>();

        return services;
    }
}
