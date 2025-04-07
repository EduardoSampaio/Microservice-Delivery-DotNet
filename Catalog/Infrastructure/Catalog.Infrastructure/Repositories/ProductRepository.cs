using System.Linq;
using System.Linq.Expressions;
using BuildingBlocks.Exceptions;
using BuildingBlocks.Wrappers.http;
using Catalog.Application.Interfaces;
using Catalog.Entities;
using Catalog.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Catalog.Infrastructure.Repositories;
/**
 * ProductRepository class implements IProductRepository interface to manage product-related operations.
 * It provides methods to create, update, delete, and retrieve products.
 */
public class ProductRepository : IProductRepository
{
    private readonly AppDbContext _context;

    public ProductRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task Create(Product product)
    {
        _context.Products.Add(product);
        await _context.SaveChangesAsync();
    }

    public async Task Delete(Product product)
    {    
        _context.Products.Remove(product);
        await _context.SaveChangesAsync();

    }

    public async Task<PagedResult<Product>> GetPagedAsync(
        Expression<Func<Product, bool>>? filter = null,
        Func<IQueryable<Product>, IOrderedQueryable<Product>>? orderBy = null,
        int pageIndex = 0,
        int pageSize = 10
        )
    {
        IQueryable<Product> query = _context.Products;

        if (filter != null)
        {
            query = query.Where(filter);
        }

        var totalCount = await query.CountAsync();

        if (orderBy != null)
        {
            query = orderBy(query);
        }

        var items = await query
            .Skip(pageIndex * pageSize)
            .Take(pageSize)
            .ToListAsync();

        return new PagedResult<Product>
        {
            Items = items,
            TotalCount = totalCount,
            PageIndex = pageIndex,
            PageSize = pageSize
        };
    }

    public async Task<IEnumerable<Product>> GetProductByCategory(int categoryId)
    {
        return await _context.Products
                             .Where(p => p.CategoryId == categoryId)
                             .AsNoTracking()
                             .ToListAsync();
    }

    public async Task<Product?> GetProductById(int id)
    {
        return await _context.Products
                             .Include(p => p.Category)
                             .FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task<IEnumerable<Product>> GetProducts()
    {
        return await _context.Products
                             .Include(p => p.Category)
                             .AsNoTracking()
                             .ToListAsync();
    }

    public async Task Update(Product product)
    {
        _context.Products.Update(product);
        await _context.SaveChangesAsync();
    }
}

