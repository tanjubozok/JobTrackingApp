using JobTracking.Entities.Models;
using JobTracking.Repositories.Abstract;
using JobTracking.Repositories.Context;

namespace JobTracking.Repositories.Repository;

public class NotificationRepository : BaseRepository<Notification>, INotificationRepository
{
    public NotificationRepository(DatabaseContext context) : base(context)
    {
    }
}
