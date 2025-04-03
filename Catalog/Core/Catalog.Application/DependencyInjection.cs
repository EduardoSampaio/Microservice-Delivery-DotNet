using Catalog.Application.Interfaces;
using Catalog.Application.Services;
using Microsoft.Extensions.DependencyInjection;
using Mapster;
using Catalog.Application.Mapster;
using FluentValidation;
using Catalog.Application.DTOs;
using Catalog.Application.Validators;

namespace Catalog.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        // Add all services here
        services.AddScoped<IProductService, ProductService>();
        services.AddScoped<ICategoryService, CategoryService>();

        services.AddScoped<IValidator<CreateCategoryDto>, CreateCategoryDtoValidator>();
        services.AddScoped<IValidator<CategoryDto>, UpdateCategoryDtoValidator>();
        services.AddScoped<IValidator<CreateProductDto>, CreateProductDtoValidator>();
        services.AddScoped<IValidator<UpdateProductDto>, UpdateProductDtoValidator>();
        
        //Mapster
        // Register Mapster
        services.AddMapster();

        // Configure Mapster
        MapsterConfig.Configure();

        return services;
    }
}
