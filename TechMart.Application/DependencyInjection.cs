using Microsoft.Extensions.DependencyInjection;
using TechMart.Application.Interfaces;
using TechMart.Application.Queries.Products;
using TechMart.Application.Services;

namespace TechMart.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(typeof(GetAllProductsQuery).Assembly); 
            });


            services.AddScoped<IProductService, ProductService>();
            return services;
        }
    }
}
