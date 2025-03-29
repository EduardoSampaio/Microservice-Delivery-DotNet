namespace Catalog.Application.DTOs;

public record CreateProductDto(string Name, string? Description, string? ImageUrl, decimal Price, int CategoryId);
