using JobTracking.Repositories.Abstract;
using JobTracking.Repositories.Context;

namespace JobTracking.Repositories.UnitOfWorks;

public class UnitOfWork : IUnitOfWork
{
    private readonly DatabaseContext _context;

    public UnitOfWork(DatabaseContext context)
        => _context = context;

    public int Commit()
         => _context.SaveChanges();

    public Task<int> CommitAsync()
        => _context.SaveChangesAsync();
}
