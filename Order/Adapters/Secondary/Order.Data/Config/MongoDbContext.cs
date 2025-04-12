using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using Order.Domain.Entities;

namespace Order.Data.Config;

public class MongoDbContext
{
    private readonly IMongoDatabase _database;

    public MongoDbContext(IConfiguration configuration)
    {
        var client = new MongoClient(configuration["MongoDb:ConnectionString"]);
        _database = client.GetDatabase(configuration["MongoDb:DatabaseName"]);
    }

    public IMongoCollection<ShoppingCart> ShoppingCart => _database.GetCollection<ShoppingCart>("ShoppingCarts");
    public IMongoCollection<BasketCheckout> BasketCheckout => _database.GetCollection<BasketCheckout>("BasketCheckout");
}
