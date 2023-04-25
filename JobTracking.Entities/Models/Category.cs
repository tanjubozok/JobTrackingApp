using JobTracking.Entities.Abstract;

namespace JobTracking.Entities.Models;

public class Category : IBaseEntity
{
    public int Id { get; set; }
    public string? Definition { get; set; }
    public string? Description { get; set; }
    public bool IsActive { get; set; }
    public bool IsDeleted { get; set; } = false;
    public DateTime CreatedDate { get; set; }
    public DateTime? ModifiedDate { get; set; }

    public List<Working>? Workings { get; set; }
}
