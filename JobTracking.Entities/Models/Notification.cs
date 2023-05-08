using JobTracking.Entities.Abstract;

namespace JobTracking.Entities.Models;

public class Notification : IBaseEntity
{
    public int Id { get; set; }
    public string? Description { get; set; }
    public bool Status { get; set; }

    public int AppUserId { get; set; }
    public AppUser? AppUser { get; set; }
}
