using Catalog.Entities;

namespace Catalog.Application.DTOs;

public record ProductDto(int Id, string Name, string? Description, string? ImageUrl, decimal Price, CategoryDto CategoryDto);
