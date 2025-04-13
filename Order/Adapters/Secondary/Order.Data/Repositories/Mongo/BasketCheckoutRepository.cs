using MongoDB.Driver;
using Order.Data.Config;
using Order.Domain.Entities;
using Order.Domain.Repositories;

namespace Order.Data.Repositories.Mongo;

public class BasketCheckoutRepository : IBasketCheckoutRepository
{
    private readonly IMongoCollection<BasketCheckout> _collection;
    public BasketCheckoutRepository(MongoDbContext context)
    {
        _collection = context.BasketCheckout;
    }

    public async Task AddAsync(BasketCheckout basket)
    {
        await _collection.InsertOneAsync(basket);
    }
    public async Task DeleteAsync(string id)
    {
        var filter = Builders<BasketCheckout>.Filter.Eq(b => b.Id, id);
        await _collection.DeleteOneAsync(filter);
    }
    public async Task<IEnumerable<BasketCheckout>> GetAllAsync()
    {
        return await _collection.Find(_ => true).ToListAsync();
    }
    public async Task<BasketCheckout?> GetByIdAsync(string id)
    {
        var filter = Builders<BasketCheckout>.Filter.Eq(b => b.Id, id);
        return await _collection.Find(filter).FirstOrDefaultAsync();
    }
    public async Task UpdateAsync(BasketCheckout basket)
    {
        var filter = Builders<BasketCheckout>.Filter.Eq(b => b.Id, basket.Id);
        await _collection.ReplaceOneAsync(filter, basket);
    }
}

