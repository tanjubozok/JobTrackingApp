using JobTracking.Entities.Models;
using JobTracking.Repositories.Abstract;
using JobTracking.Repositories.Context;

namespace JobTracking.Repositories.Repository;

public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
{
    public CategoryRepository(DatabaseContext context)
        : base(context)
    {
    }
}