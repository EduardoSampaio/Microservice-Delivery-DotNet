using Catalog.Application.Interfaces;
using Catalog.Application.Services;
using Microsoft.Extensions.DependencyInjection;
using Mapster;
using Catalog.Application.Mapster;

namespace Catalog.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        // Add all services here
        services.AddScoped<IProductService, ProductService>();
        services.AddScoped<ICategoryService, CategoryService>();

        //Mapster
        // Register Mapster
        services.AddMapster();

        // Configure Mapster
        MapsterConfig.Configure();

        return services;
    }
}
