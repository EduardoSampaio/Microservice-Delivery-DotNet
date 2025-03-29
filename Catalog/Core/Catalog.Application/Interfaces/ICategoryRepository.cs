using Catalog.Entities;

namespace Catalog.Application.Interfaces;

public interface ICategoryRepository
{
    Task<IEnumerable<Category>> GetCategories();
    Task<Category?> GetCategoryById(int id);
    Task Create(Category category);
    Task Update(Category category);
    Task Delete(Category category);
}
