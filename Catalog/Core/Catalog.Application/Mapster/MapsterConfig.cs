using Catalog.Application.DTOs;
using Catalog.Entities;
using Mapster;

namespace Catalog.Application.Mapster;

public static class MapsterConfig
{
    public static void Configure()
    {
        TypeAdapterConfig<Product, ProductDto>.NewConfig()
            .Map(dest => dest.Id, src => src.Id)
            .Map(dest => dest.Name, src => src.Name)
            .Map(dest => dest.Description, src => src.Description)
            .Map(dest => dest.Price, src => src.Price)
            .Map(dest => dest.ImageUrl, src => src.ImageUrl)
            .Map(dest => dest.CategoryDto.Id, src => src.Category.Id)
            .Map(dest => dest.CategoryDto.Name, src => src.Category.Name)
            .Map(dest => dest.CategoryDto.Description, src => src.Category.Description);

        TypeAdapterConfig<Product, CreateProductDto>.NewConfig()
            .Map(dest => dest.Name, src => src.Name)
            .Map(dest => dest.Description, src => src.Description)
            .Map(dest => dest.Price, src => src.Price)
            .Map(dest => dest.ImageUrl, src => src.ImageUrl)
            .Map(dest => dest.CategoryId, src => src.Category.Id);
      
        TypeAdapterConfig<Category, CategoryDto>.NewConfig()
            .Map(dest => dest.Name, src => src.Name)
            .Map(dest => dest.Description, src => src.Description)
            .Map(dest => dest.Id, src => src.Id);

        TypeAdapterConfig<Category, CreateCategoryDto>.NewConfig()
            .Map(dest => dest.Name, src => src.Name)
            .Map(dest => dest.Description, src => src.Description);      
    }
}
