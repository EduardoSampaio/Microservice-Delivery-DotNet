using BuildingBlocks.Exceptions;
using BuildingBlocks.Wrappers.http;
using Catalog.Application.DTOs;
using Catalog.Application.Interfaces;
using Catalog.Entities;
using Mapster;

namespace Catalog.Application.Services;

public class CategoryService(ICategoryRepository categoryRepository) : ICategoryService
{
    public async Task<IResponseWrapper> Create(CreateCategoryDto categoryDto)
    {
        var entity = categoryDto.Adapt<Category>();
        await categoryRepository.Create(entity);
        return await ResponseWrapper.SuccessAsync();
    }


    public async Task<IResponseWrapper> Delete(int id)
    {
        var entity = await categoryRepository.GetCategoryById(id) ?? throw new EntityNotFoundException(
            ["Category not found"]);

        await categoryRepository.Delete(entity);

        return await ResponseWrapper.SuccessAsync();
    }

    public async Task<IResponseWrapper> GetCategories()
    {
        var entities = await categoryRepository.GetCategories();

        var dtos = entities.Adapt<IEnumerable<CategoryDto>>();
        return await ResponseWrapper<IEnumerable<CategoryDto>>.SuccessAsync(data: dtos);
    }
    public async Task<IResponseWrapper> GetCategoryById(int id)
    {
        var entity = await categoryRepository.GetCategoryById(id) ?? throw new EntityNotFoundException(
         ["Category not found"]);

        var dto = entity.Adapt<CategoryDto>();
        return await ResponseWrapper<CategoryDto>.SuccessAsync(data: dto);
    }
    public async Task<IResponseWrapper> Update(CategoryDto categoryDto)
    {
        var entity = await categoryRepository.GetCategoryById(categoryDto.Id) ?? throw new EntityNotFoundException(["Category not found"]);
        entity.Name = categoryDto.Name;
        entity.Description = categoryDto.Description;

        await categoryRepository.Update(entity);

        return await ResponseWrapper.SuccessAsync();
    }
}
