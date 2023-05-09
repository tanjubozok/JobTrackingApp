using JobTracking.Entities.Models;

namespace JobTracking.Repositories.Abstract;

public interface INotificationRepository : IBaseRepository<Notification>
{
    Task<Notification> DoneNotification(int notificationId);
    Task<List<Notification>> GetAllByAppUserId(int appUserId);
    int GetAllByAppUserIdCount(int appUserId);
    Task<int> GetNumberOfUnreadNotificationAsync(int appUserId);
}
