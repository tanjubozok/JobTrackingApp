using JobTracking.Dtos.Abstract;

namespace JobTracking.Dtos.CategoryDtos;

public class CategoryCreateDto : IBaseDto
{
    public string? Definition { get; set; }
    public string? Description { get; set; }
    public bool IsActive { get; set; }
}