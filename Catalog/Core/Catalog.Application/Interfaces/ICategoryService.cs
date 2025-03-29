using Catalog.Application.DTOs;
using Catalog.Entities;

namespace Catalog.Application.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryDto>> GetCategories();
        Task<CategoryDto?> GetCategoryById(int id);
        Task Create(CreateCategoryDto categoryDto);
        Task Update(CategoryDto categoryDto);
        Task Delete(int id);
    }
}
