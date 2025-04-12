using System.Linq.Expressions;
using Order.Domain.Common.Interfaces;

namespace Order.Domain.Repositories;

public interface IBaseRepository<T> where T : IEntity
{
    Task<T> AddAsync(T entity, CancellationToken cancellationToken);
    Task UpdateAsync(T entity);
    Task DeleteAsync(T entity);
    Task DeleteManyAsync(Expression<Func<T, bool>> filter);
    Task<IEnumerable<T>> GetAllAsync();
    Task<T?> GetByIdAsync(params object[] id);
    Task<IEnumerable<T>> GetManyAsync(Expression<Func<T, bool>>? filter = null,
                                      Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
                                      int? top = null,
                                      int? skip = null,
                                      params string[] includeProperties);
}
