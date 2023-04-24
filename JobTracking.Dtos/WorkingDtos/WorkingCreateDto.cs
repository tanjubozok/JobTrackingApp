using JobTracking.Dtos.Abstract;

namespace JobTracking.Dtos.WorkingDtos;

public class WorkingCreateDto : IBaseDto
{
    public string? Definition { get; set; }
    public string? Description { get; set; }
    public int? AppUserId { get; set; }
    public int CategoryId { get; set; }
}