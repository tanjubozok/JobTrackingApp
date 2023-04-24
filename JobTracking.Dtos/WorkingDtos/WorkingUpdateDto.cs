using JobTracking.Dtos.Abstract;

namespace JobTracking.Dtos.WorkingDtos;

public class WorkingUpdateDto : IBaseDto
{
    public int Id { get; set; }
    public string? Definition { get; set; }
    public string? Description { get; set; }
    public bool Status { get; set; }
    public int? AppUserId { get; set; }
    public int CategoryId { get; set; }
}