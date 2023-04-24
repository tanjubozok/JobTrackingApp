using JobTracking.Entities.Abstract;
using System.Linq.Expressions;

namespace JobTracking.Repositories.Abstract;

public interface IBaseRepository<T> where T : class, IBaseEntity, new()
{
    Task<List<T>> GetAllAsync(Expression<Func<T, bool>>? filter = null);

    Task<T?> GetOneAsync(Expression<Func<T, bool>>? filter = null);
    Task<T?> GetByIdAsync(object id);

    IQueryable<T> GetQuery();

    Task<bool> GetAnyAsync(Expression<Func<T, bool>>? filter = null);
    Task<int> GetCountAsync(Expression<Func<T, bool>>? filter = null);

    Task<T> CreateAsync(T entity);
    Task Update(T entity, T unchanged);
}
