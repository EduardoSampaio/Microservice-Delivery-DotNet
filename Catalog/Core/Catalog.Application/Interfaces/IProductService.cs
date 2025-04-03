using BuildingBlocks.Wrappers.http;
using Catalog.Application.DTOs;

namespace Catalog.Application.Interfaces
{
    public interface IProductService
    {
        Task<IResponseWrapper> GetProducts();
        Task<IResponseWrapper> GetProductById(int id);
        Task<IResponseWrapper> GetProductByCategory(int categoryId);
        Task<IResponseWrapper> Create(CreateProductDto product);
        Task<IResponseWrapper> Update(UpdateProductDto product);
        Task<IResponseWrapper> Delete(int id);
    }
}
