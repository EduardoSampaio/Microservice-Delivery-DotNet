using BuildingBlocks.Exceptions;
using Catalog.Application.Interfaces;
using Catalog.Entities;
using Catalog.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Catalog.Infrastructure.Repositories;

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
                             .Include(p => p.Category)  // Eager load the Category
                             .AsNoTracking()
                             .ToListAsync();
    }

    public async Task Update(Product product)
    {
        _context.Products.Update(product);
        await _context.SaveChangesAsync();
    }
}

