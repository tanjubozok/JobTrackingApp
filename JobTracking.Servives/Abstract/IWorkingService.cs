﻿using JobTracking.Common.Abstract;
using JobTracking.Dtos.WorkingDtos;

namespace JobTracking.Servives.Abstract;

public interface IWorkingService
{
    Task<IResponse<List<WorkingListDto>>> GetAllAsync();
    Task<IResponse<List<WorkingListDto>>> GetAllWithCategoryAsync();
    Task<IResponse<WorkingUpdateDto>> GetByIdAsync(int id);
    Task<IResponse<WorkingCreateDto>> CreateAsync(WorkingCreateDto dto);
    Task<IResponse<WorkingUpdateDto>> UpdateAsync(WorkingUpdateDto dto);
}