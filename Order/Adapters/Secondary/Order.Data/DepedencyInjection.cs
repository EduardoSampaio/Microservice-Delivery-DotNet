using Microsoft.Extensions.DependencyInjection;
using Order.Data.Repositories.EF;
using Order.Data.Repositories.Mongo;
using Order.Domain.Repositories;

namespace Order.Application;

public static class DepedencyInjection
{
    public static IServiceCollection AddData(this IServiceCollection services)
    {
        services.AddTransient(typeof(IBaseRepository<>), typeof(BaseRepository<>));
        services.AddTransient<IOrderRepository, OrderRepository>();
        services.AddTransient<IBasketCheckoutRepository, BasketCheckoutRepository>();
        services.AddTransient<IShoppingCartRepository, ShoppingCartRepository>();
        return services;
    }
}
