using JobTracking.Entities.Abstract;
using System.Linq.Expressions;

namespace JobTracking.Repositories.Abstract;

public interface IBaseRepository<T> where T : class, IBaseEntity, new()
{
    Task<List<T>> GetAllAsync(Expression<Func<T, bool>>? filter = null);

    Task<T?> GetOneAsync(Expression<Func<T, bool>>? filter = null);
    Task<T?> GetByIdAsync(object id);

    IQueryable<T> GetQuery(Expression<Func<T, bool>>? filter = null);

    Task<bool> GetAnyAsync(Expression<Func<T, bool>>? filter = null);
    Task<int> GetCountAsync(Expression<Func<T, bool>>? filter = null);

    Task<T> CreateAsync(T entity);
    void Update(T entity, T unchanged);
}
