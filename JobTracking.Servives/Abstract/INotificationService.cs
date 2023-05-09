using JobTracking.Common.Abstract;
using JobTracking.Dtos.NotificationDtos;

namespace JobTracking.Services.Abstract;

public interface INotificationService
{
    Task<IResponse<NotificationCreateDto>> CreateAsync(int appUserId, string description);
    Task<IResponse<List<NotificationListDto>>> GetAllAsync(int appUserId);
    int NotificationCount(int appUserId);
    Task<IResponse<NotificationUpdateDto>> DoneNotificationAsync(int notificationId);
    Task<int> GetNumberOfUnreadNotificationAsync(int appUserId);
}
