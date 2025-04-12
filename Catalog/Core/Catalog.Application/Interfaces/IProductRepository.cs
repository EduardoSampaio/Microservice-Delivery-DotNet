using System.Linq.Expressions;
using BuildingBlocks.Wrappers.http;
using Catalog.Entities;

namespace Catalog.Application.Interfaces;

public interface IProductRepository
{
    Task<PagedResult<Product>> GetPagedAsync(
        Expression<Func<Product, bool>>? filter = null,
        Func<IQueryable<Product>, IOrderedQueryable<Product>>? orderBy = null,
        int pageIndex = 0,
        int pageSize = 10,
        params string[] includeProperties
    );

    Task<Product?> GetProductById(int id);
    Task<IEnumerable<Product>> GetProductByCategory(int categoryId);
    Task Create(Product product);
    Task Update(Product product);
    Task Delete(Product product);
}
