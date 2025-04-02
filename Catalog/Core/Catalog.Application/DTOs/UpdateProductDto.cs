namespace Catalog.Application.DTOs;

public record UpdateProductDto(int Id, string Name, string? Description, string? ImageUrl, decimal Price, int CategoryId);
