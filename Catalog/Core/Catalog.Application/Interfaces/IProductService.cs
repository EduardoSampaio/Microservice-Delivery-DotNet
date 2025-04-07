using System.Linq.Expressions;
using BuildingBlocks.Wrappers.http;
using Catalog.Application.DTOs;
using Catalog.Entities;

namespace Catalog.Application.Interfaces
{
    public interface IProductService
    {
        Task<IResponseWrapper> GetPagedAsync(QueryParameters queryParameters);
        Task<IResponseWrapper> GetProductById(int id);
        Task<IResponseWrapper> GetProductByCategory(int categoryId);
        Task<IResponseWrapper> Create(CreateProductDto product);
        Task<IResponseWrapper> Update(UpdateProductDto product);
        Task<IResponseWrapper> Delete(int id);
    }
}
