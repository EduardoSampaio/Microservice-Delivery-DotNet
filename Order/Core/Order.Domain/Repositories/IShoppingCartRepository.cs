using Order.Domain.Entities;

namespace Order.Domain.Repositories;

public interface IShoppingCartRepository
{
    Task<ShoppingCart?> GetByIdAsync(string id);
    Task<IEnumerable<ShoppingCart>> GetAllAsync();
    Task AddAsync(ShoppingCart shoppingCart);
    Task UpdateAsync(ShoppingCart shoppingCart);
    Task DeleteAsync(string id);
}
