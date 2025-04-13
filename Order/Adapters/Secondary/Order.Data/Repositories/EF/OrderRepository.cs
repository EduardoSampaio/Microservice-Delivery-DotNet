using Order.Data.Config;
using Order.Domain.Repositories;

namespace Order.Data.Repositories.EF;

public class OrderRepository: BaseRepository<Domain.Entities.Order>, IOrderRepository
{
    public OrderRepository(AppDbContext context) : base(context)
    {
    }
}
