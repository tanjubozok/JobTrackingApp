using JobTracking.Dtos.Abstract;
using JobTracking.Entities.Models;

namespace JobTracking.Dtos.NotificationDtos;

public class NotificationListDto : IBaseDto
{
    public int Id { get; set; }
    public string? Description { get; set; }
    public bool Status { get; set; }

    public int AppUserId { get; set; }
    public AppUser? AppUser { get; set; }
}
