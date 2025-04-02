using Catalog.Application.DTOs;

namespace Catalog.Application.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDto>> GetProducts();
        Task<ProductDto> GetProductById(int id);
        Task<IEnumerable<ProductDto>> GetProductByCategory(int categoryId);
        Task Create(CreateProductDto product);
        Task Update(UpdateProductDto product);
        Task Delete(int id);
    }
}
