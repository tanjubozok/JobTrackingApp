using JobTracking.Dtos.Abstract;

namespace JobTracking.Dtos.CategoryDtos;

public class CategoryUpdateDto : IBaseDto
{
    public int Id { get; set; }
    public string? Definition { get; set; }
    public string? Description { get; set; }
    public bool IsActive { get; set; }
}