using Catalog.Application.DTOs;
using Catalog.Application.Interfaces;

namespace Catalog.Application.Services;

public class ProductService : IProductService
{
    public Task Create(CreateProductDto product) => throw new NotImplementedException();
    public Task Delete(int id) => throw new NotImplementedException();
    public Task<IEnumerable<ProductDto>> GetProductByCategory(int categoryId) => throw new NotImplementedException();
    public Task<ProductDto> GetProductById(int id) => throw new NotImplementedException();
    public Task<IEnumerable<ProductDto>> GetProducts() => throw new NotImplementedException();
    public Task Update(ProductDto product) => throw new NotImplementedException();
}
