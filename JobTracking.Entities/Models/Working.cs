using JobTracking.Entities.Abstract;

namespace JobTracking.Entities.Models;

public class Working : IBaseEntity
{
    public int Id { get; set; }
    public string? Definition { get; set; }
    public string? Description { get; set; }
    public bool Status { get; set; } = true;
    public DateTime CreatedDate { get; set; } = DateTime.Now;

    public int? AppUserId { get; set; }
    public AppUser? AppUser { get; set; }

    public int CategoryId { get; set; }
    public Category? Category { get; set; }

    public List<Reporting>? Reportings { get; set; }
}
