using JobTracking.Dtos.Abstract;

namespace JobTracking.Dtos.GraphicDtos;

public class GraphicListDto : IBaseDto
{
    public string? Username { get; set; }
    public int TaskCount { get; set; }
}
