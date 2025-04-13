using MongoDB.Driver;
using Order.Data.Config;
using Order.Domain.Entities;
using Order.Domain.Repositories;

namespace Order.Data.Repositories.Mongo;

public class ShoppingCartRepository : IShoppingCartRepository
{
    private readonly IMongoCollection<ShoppingCart> _collection;
    public ShoppingCartRepository(MongoDbContext context)
    {
        _collection = context.ShoppingCart;
    }
    public async Task AddAsync(ShoppingCart shoppingCart)
    {
        await _collection.InsertOneAsync(shoppingCart);
    }
    public async Task DeleteAsync(string id)
    {
        var filter = Builders<ShoppingCart>.Filter.Eq(b => b.Id, id);
        await _collection.DeleteOneAsync(filter);
    }
    public async Task<IEnumerable<ShoppingCart>> GetAllAsync()
    {
        return await _collection.Find(_ => true).ToListAsync();
    }
    public async Task<ShoppingCart?> GetByIdAsync(string id)
    {
        var filter = Builders<ShoppingCart>.Filter.Eq(b => b.Id, id);
        return await _collection.Find(filter).FirstOrDefaultAsync();
    }
    public async Task UpdateAsync(ShoppingCart shoppingCart)
    {
        var filter = Builders<ShoppingCart>.Filter.Eq(b => b.Id, shoppingCart.Id);
        await _collection.ReplaceOneAsync(filter, shoppingCart);
    }
}

