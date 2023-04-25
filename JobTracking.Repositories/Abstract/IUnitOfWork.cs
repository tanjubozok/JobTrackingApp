namespace JobTracking.Repositories.Abstract;

public interface IUnitOfWork
{
    Task<int> CommitAsync();
    int Commit();
}