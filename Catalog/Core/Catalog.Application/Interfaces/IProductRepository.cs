using Catalog.Entities;

namespace Catalog.Application.Interfaces;

public interface IProductRepository
{
    Task<IEnumerable<Product>> GetProducts();
    Task<Product?> GetProductById(int id);
    Task<IEnumerable<Product>> GetProductByCategory(int categoryId);
    Task Create(Product product);
    Task Update(Product product);
    Task Delete(Product product);
}
