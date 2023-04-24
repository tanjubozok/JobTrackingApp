using JobTracking.Entities.Abstract;
using JobTracking.Repositories.Abstract;
using JobTracking.Repositories.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace JobTracking.Repositories.Repository;

public class BaseRepository<T> : IBaseRepository<T> where T : class, IBaseEntity, new()
{
    private readonly DatabaseContext _context;

    public BaseRepository(DatabaseContext context)
        => _context = context;

    public async Task<T> CreateAsync(T entity)
    {
        await _context.Set<T>().AddAsync(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task<List<T>> GetAllAsync(Expression<Func<T, bool>>? filter = null)
        => filter == null
        ? await _context.Set<T>().AsNoTracking().ToListAsync()
        : await _context.Set<T>().Where(filter).AsNoTracking().ToListAsync();

    public async Task<bool> GetAnyAsync(Expression<Func<T, bool>>? filter = null)
        => filter == null
        ? await _context.Set<T>().AsNoTracking().AnyAsync()
        : await _context.Set<T>().Where(filter).AsNoTracking().AnyAsync();

    public async Task<T?> GetByIdAsync(object id)
        => await _context.Set<T>().FindAsync(id);

    public async Task<int> GetCountAsync(Expression<Func<T, bool>>? filter = null)
        => filter == null
        ? await _context.Set<T>().AsNoTracking().CountAsync()
        : await _context.Set<T>().Where(filter).AsNoTracking().CountAsync();

    public async Task<T?> GetOneAsync(Expression<Func<T, bool>>? filter = null)
        => filter == null
        ? await _context.Set<T>().AsNoTracking().SingleOrDefaultAsync()
        : await _context.Set<T>().Where(filter).AsNoTracking().SingleOrDefaultAsync();

    public IQueryable<T> GetQuery()
        => _context.Set<T>().AsNoTracking().AsQueryable();

    public async Task Update(T entity, T unchanged)
    {
        _context.Entry(unchanged).CurrentValues.SetValues(entity);
        await _context.SaveChangesAsync();
    }
}

