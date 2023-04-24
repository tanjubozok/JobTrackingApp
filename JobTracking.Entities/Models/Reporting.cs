using JobTracking.Entities.Abstract;

namespace JobTracking.Entities.Models;

public class Reporting : IBaseEntity
{
    public int Id { get; set; }
    public string? Definition { get; set; }
    public string? Detail { get; set; }

    public int WorkingId { get; set; }
    public Working? Working { get; set; }
}
