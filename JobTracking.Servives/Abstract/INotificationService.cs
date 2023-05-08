using JobTracking.Common.Abstract;
using JobTracking.Dtos.NotificationDtos;

namespace JobTracking.Services.Abstract;

public interface INotificationService
{
    Task<IResponse<NotificationCreateDto>> CreateAsync(NotificationCreateDto dto);
}
