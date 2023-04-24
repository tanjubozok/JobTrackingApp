using JobTracking.Common.Abstract;
using JobTracking.Dtos.WorkingDtos;
using JobTracking.Servives.Abstract;

namespace JobTracking.Servives.Manager;

public class WorkingManager : IWorkingService
{
    public Task<IResponse<WorkingCreateDto>> CreateAsync(WorkingCreateDto dto)
    {
        throw new NotImplementedException();
    }

    public Task<IResponse<List<WorkingListDto>>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<List<WorkingListDto>> GetAllWithCategoryAsync()
    {
        throw new NotImplementedException();
    }

    public Task<IResponse<WorkingListDto>> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IResponse<WorkingUpdateDto>> UpdateAsync(WorkingUpdateDto dto)
    {
        throw new NotImplementedException();
    }
}
