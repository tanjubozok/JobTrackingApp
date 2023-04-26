using JobTracking.Entities.Abstract;
using JobTracking.Repositories.Abstract;
using JobTracking.Repositories.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace JobTracking.Repositories.Repository;

public class BaseRepository<T> : IBaseRepository<T>
    where T : class, IBaseEntity, new()
{
    protected readonly DatabaseContext _context;
    private readonly DbSet<T> _table;

    public BaseRepository(DatabaseContext context)
    {
        _context = context;
        _table = _context.Set<T>();
    }

    public async Task<T> CreateAsync(T entity)
    {
        await _table.AddAsync(entity);
        return entity;
    }

    public async Task<List<T>> GetAllAsync(Expression<Func<T, bool>>? filter = null)
        => filter == null
        ? await _table.AsNoTracking().ToListAsync()
        : await _table.Where(filter).AsNoTracking().ToListAsync();

    public async Task<bool> GetAnyAsync(Expression<Func<T, bool>>? filter = null)
        => filter == null
        ? await _table.AsNoTracking().AnyAsync()
        : await _table.Where(filter).AsNoTracking().AnyAsync();

    public async Task<T?> GetByIdAsync(object id)
        => await _table.FindAsync(id);

    public async Task<int> GetCountAsync(Expression<Func<T, bool>>? filter = null)
        => filter == null
        ? await _table.AsNoTracking().CountAsync()
        : await _table.Where(filter).AsNoTracking().CountAsync();

    public async Task<T?> GetOneAsync(Expression<Func<T, bool>>? filter = null)
        => filter == null
        ? await _table.AsNoTracking().SingleOrDefaultAsync()
        : await _table.Where(filter).AsNoTracking().SingleOrDefaultAsync();

    public IQueryable<T> GetQuery(Expression<Func<T, bool>>? filter = null)
        => filter == null
        ? _table.AsNoTracking().AsQueryable()
        : _table.Where(filter).AsNoTracking().AsQueryable();

    public void Update(T entity, T unchanged)
        => _context.Entry(unchanged).CurrentValues.SetValues(entity);
}

