using BuildingBlocks.Exceptions;
using Catalog.Application.DTOs;
using Catalog.Application.Interfaces;
using Catalog.Entities;
using Mapster;

namespace Catalog.Application.Services;

public class CategoryService(ICategoryRepository categoryRepository) : ICategoryService
{
    public async Task Create(CreateCategoryDto categoryDto)
    {
        var entity = categoryDto.Adapt<Category>();
        await categoryRepository.Create(entity);
    }


    public async Task Delete(int id)
    {
        var entity = await categoryRepository.GetCategoryById(id) ?? throw new EntityNotFoundException();

        await categoryRepository.Delete(entity);
    }

    public async Task<IEnumerable<CategoryDto>> GetCategories()
    {
        var entities = await categoryRepository.GetCategories();

        return entities.Adapt<IEnumerable<CategoryDto>>();
    }
    public async Task<CategoryDto?> GetCategoryById(int id)
    {
        var entity = await categoryRepository.GetCategoryById(id) ?? throw new EntityNotFoundException();

        return entity.Adapt<CategoryDto>();
    }
    public Task Update(CategoryDto categoryDto)
    {
        var entity = categoryDto.Adapt<Category>();
        categoryRepository.Update(entity);
        return Task.CompletedTask;
    }
}
