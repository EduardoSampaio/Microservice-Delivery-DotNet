using BuildingBlocks.Wrappers.http;
using Catalog.Application.DTOs;
using Catalog.Entities;

namespace Catalog.Application.Interfaces
{
    public interface ICategoryService
    {
        Task<IResponseWrapper> GetCategories();
        Task<IResponseWrapper> GetCategoryById(int id);
        Task<IResponseWrapper> Create(CreateCategoryDto categoryDto);
        Task<IResponseWrapper> Update(CategoryDto categoryDto);
        Task<IResponseWrapper> Delete(int id);
    }
}
