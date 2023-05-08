using JobTracking.Dtos.Abstract;

namespace JobTracking.Dtos.NotificationDtos;

public class NotificationCreateDto : IBaseDto
{
    public string? Description { get; set; }
    public int AppUserId { get; set; }
}
