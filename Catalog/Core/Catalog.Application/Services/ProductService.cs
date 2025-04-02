using BuildingBlocks.Exceptions;
using Catalog.Application.DTOs;
using Catalog.Application.Interfaces;
using Catalog.Entities;
using Mapster;

namespace Catalog.Application.Services;

public class ProductService(IProductRepository productRepository) : IProductService
{
    public async Task Create(CreateProductDto product)
    {
        var entity = product.Adapt<Product>();
        await productRepository.Create(entity);
    }
    public async Task Delete(int id)
    {
        var entity = await productRepository.GetProductById(id) ?? throw new EntityNotFoundException();
        await productRepository.Delete(entity);
    }
    public async Task Update(UpdateProductDto product)
    {
        var entity = await productRepository.GetProductById(product.Id) ?? throw new EntityNotFoundException();
        entity.Name = product.Name;
        entity.Description = product.Description;
        entity.Price = product.Price;
        entity.CategoryId = product.CategoryId;
        entity.ImageUrl = product.ImageUrl;

        await productRepository.Update(entity);
    }

    public async Task<IEnumerable<ProductDto>> GetProductByCategory(int categoryId) {
        var products = await productRepository.GetProductByCategory(categoryId);

        return products.Adapt<IEnumerable<ProductDto>>();
    }
    public async Task<ProductDto> GetProductById(int id)
    {
        var entity =  await productRepository.GetProductById(id) ?? throw new EntityNotFoundException();
        return entity.Adapt<ProductDto>();
    }
    public async Task<IEnumerable<ProductDto>> GetProducts()
    {
        var products = await productRepository.GetProducts();

        return products.Adapt<IEnumerable<ProductDto>>();
    }
}
