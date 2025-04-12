using Order.Domain.Entities;

namespace Order.Domain.Repositories;

public interface IBasketCheckoutRepository
{
    Task<BasketCheckout?> GetByIdAsync(string id);
    Task<IEnumerable<BasketCheckout>> GetAllAsync();
    Task AddAsync(BasketCheckout basket);
    Task UpdateAsync(BasketCheckout basket);
    Task DeleteAsync(string id);
}
