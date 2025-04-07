using System.Linq.Expressions;
using BuildingBlocks.Exceptions;
using BuildingBlocks.Wrappers.http;
using Catalog.Application.DTOs;
using Catalog.Application.Interfaces;
using Catalog.Entities;
using Mapster;

namespace Catalog.Application.Services;

public class ProductService(IProductRepository productRepository) : IProductService
{
    public async Task<IResponseWrapper> Create(CreateProductDto product)
    {
        var entity = product.Adapt<Product>();
        await productRepository.Create(entity);
        return await ResponseWrapper.SuccessAsync();
    }
    public async Task<IResponseWrapper> Delete(int id)
    {
        var entity = await productRepository.GetProductById(id) ?? throw new EntityNotFoundException(["Product not found"]);
        await productRepository.Delete(entity);
        return await ResponseWrapper.SuccessAsync();
    }
    public async Task<IResponseWrapper> Update(UpdateProductDto product)
    {
        var entity = await productRepository.GetProductById(product.Id) ?? throw new EntityNotFoundException(["Product not found"]);
        entity.Name = product.Name;
        entity.Description = product.Description;
        entity.Price = product.Price;
        entity.CategoryId = product.CategoryId;
        entity.ImageUrl = product.ImageUrl;

        await productRepository.Update(entity);
        return await ResponseWrapper.SuccessAsync();
    }

    public async Task<IResponseWrapper> GetProductByCategory(int categoryId) {
        var products = await productRepository.GetProductByCategory(categoryId);

        var dtos = products.Adapt<IEnumerable<ProductDto>>();
        return await ResponseWrapper<IEnumerable<ProductDto>>.SuccessAsync(data: dtos);
    }
    public async Task<IResponseWrapper> GetProductById(int id)
    {
        var entity =  await productRepository.GetProductById(id) ?? throw new EntityNotFoundException(["Product not found"]);
        var dto = entity.Adapt<ProductDto>();
        return await ResponseWrapper<ProductDto>.SuccessAsync(data: dto);
    }
    public async Task<IResponseWrapper> GetPagedAsync(QueryParameters queryParameters)
    {
        var filter = QueryParamsBuilder<Product>.BuildProductFilter(queryParameters.Filter);
        var orderBy = QueryParamsBuilder<Product>.GetOrderByDynamic(queryParameters.OrderBy, queryParameters.SortDirection);
        int pageIndex = queryParameters.PageIndex;
        int pageSize = queryParameters.PageSize;

        PagedResult<Product> paged = await productRepository.GetPagedAsync(filter, orderBy, pageIndex, pageSize);

        var dtos = paged.Items.Adapt<List<ProductDto>>();

        var pagedResult = new PagedResult<ProductDto>
        {
            Items = dtos,
            TotalCount = paged.TotalCount,
            PageIndex = paged.PageIndex,
            PageSize = paged.PageSize
        };

        return await ResponseWrapper<PagedResult<ProductDto>>.SuccessAsync(data: pagedResult);
    }
}
