using JobTracking.Entities.Models;
using JobTracking.Repositories.Abstract;
using JobTracking.Repositories.Context;
using Microsoft.EntityFrameworkCore;

namespace JobTracking.Repositories.Repository;

public class NotificationRepository : BaseRepository<Notification>, INotificationRepository
{
    public NotificationRepository(DatabaseContext context)
        : base(context)
    {
    }

    public async Task<List<Notification>> GetAllByAppUserId(int appUserId)
    {
        var notifications = _context.Notifications?
            .Include(x => x.AppUser)
            .Where(x => x.AppUserId == appUserId && !x.Status);

        return await notifications!
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<Notification> DoneNotification(int notificationId)
    {
        var notification = await _context.Notifications!
            .FirstOrDefaultAsync(x => x.Id == notificationId);
        notification!.Status = true;

        return notification;
    }

    public int GetAllByAppUserIdCount(int appUserId)
    {
        var notifications = _context.Notifications?
                    .Include(x => x.AppUser)
                    .Where(x => x.AppUserId == appUserId && !x.Status);

        return notifications!
            .AsNoTracking()
            .Count();
    }

    public async Task<int> GetNumberOfUnreadNotificationAsync(int appUserId)
    {
        var result = _context.Notifications!
            .Where(x => x.AppUserId == appUserId && !x.Status);

        return await result
            .AsNoTracking()
            .CountAsync();
    }
}
