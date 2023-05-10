using AutoMapper;
using JobTracking.Common.Abstract;
using JobTracking.Common.ComplexTypes;
using JobTracking.Common.ResponseObjects;
using JobTracking.Dtos.GraphicDtos;
using JobTracking.Dtos.WorkingDtos;
using JobTracking.Entities.Models;
using JobTracking.Repositories.Abstract;
using JobTracking.Services.Abstract;
using Microsoft.EntityFrameworkCore;

namespace JobTracking.Services.Manager;

public class WorkingManager : IWorkingService
{
    private readonly IWorkingRepository _workingRepository;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public WorkingManager(IWorkingRepository workingRepository, IMapper mapper, IUnitOfWork unitOfWork)
    {
        _workingRepository = workingRepository;
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task<IResponse<WorkingCreateDto>> CreateAsync(WorkingCreateDto dto)
    {
        var working = _mapper.Map<Working>(dto);
        working.Status = false;
        working.CreatedDate = DateTime.UtcNow;
        await _workingRepository.CreateAsync(working);
        var result = await _unitOfWork.CommitAsync();
        if (result > 0)
            return new Response<WorkingCreateDto>(ResponseType.Success, dto);
        return new Response<WorkingCreateDto>(ResponseType.SaveError, "Kayıt sırasında hata oluştu");
    }

    public async Task<IResponse<List<WorkingListDto>>> GetAllAsync()
    {
        var workingList = await _workingRepository
            .GetQuery()
            .OrderBy(x => x.CreatedDate)
            .ToListAsync();

        var workingDto = _mapper.Map<List<WorkingListDto>>(workingList);
        return new Response<List<WorkingListDto>>(ResponseType.Success, workingDto);
    }

    public async Task<IResponse<List<WorkingListDto>>> GetAllByAppUserId(int appUserId)
    {
        var workingList = await _workingRepository.GetAllByAppUserId(appUserId);

        var dto = _mapper.Map<List<WorkingListDto>>(workingList);
        return new Response<List<WorkingListDto>>(ResponseType.Success, dto);
    }

    public async Task<IResponse<WorkingListDto>> GetAllByIdWithCategoryAsync(int id)
    {
        var workingList = await _workingRepository
            .GetByIdWithCategoryAsync(id);

        var workingDto = _mapper.Map<WorkingListDto>(workingList);
        return new Response<WorkingListDto>(ResponseType.Success, workingDto);
    }

    public async Task<IResponse<List<WorkingTableListDto>>> GetAllTableAsync()
    {
        var workingTableList = await _workingRepository
            .GetAllTableAsync();

        var dto = _mapper.Map<List<WorkingTableListDto>>(workingTableList);
        return new Response<List<WorkingTableListDto>>(ResponseType.Success, dto);
    }

    public async Task<IResponse<List<WorkingTableListDto>>> GetAllTableAsync(int appUserId)
    {
        var workingTableList = await _workingRepository
                   .GetAllTableAsync(appUserId);

        var dto = _mapper.Map<List<WorkingTableListDto>>(workingTableList);
        return new Response<List<WorkingTableListDto>>(ResponseType.Success, dto);
    }

    public async Task<IResponse<List<WorkingListDto>>> GetAllWithCategoryAsync()
    {
        var workingList = await _workingRepository
            .GetAllWithCategoryAsync();

        var workingDto = _mapper.Map<List<WorkingListDto>>(workingList);
        return new Response<List<WorkingListDto>>(ResponseType.Success, workingDto);
    }

    public async Task<IResponse<WorkingUpdateDto>> GetByIdAsync(int id)
    {
        var working = await _workingRepository
            .GetByIdAsync(id);
        if (working is null)
            return new Response<WorkingUpdateDto>(ResponseType.NotFound, "İş bulunamadı");

        var workingDto = _mapper.Map<WorkingUpdateDto>(working);
        return new Response<WorkingUpdateDto>(ResponseType.Success, workingDto);
    }

    public async Task<IResponse<WorkingUpdateDto>> UpdateAsync(WorkingUpdateDto dto)
    {
        var updatedEntity = await _workingRepository
            .GetByIdAsync(dto.Id);
        if (updatedEntity is not null)
        {
            var working = _mapper.Map<Working>(dto);
            working.CreatedDate = updatedEntity.CreatedDate;
            _workingRepository.Update(working, updatedEntity);
            var result = await _unitOfWork.CommitAsync();
            if (result > 0)
                return new Response<WorkingUpdateDto>(ResponseType.Success);
            return new Response<WorkingUpdateDto>(ResponseType.SaveError, "Güncelleme olmadı.");
        }
        return new Response<WorkingUpdateDto>(ResponseType.NotFound, "İş bulunamdı");
    }

    public async Task<IResponse<WorkingUpdateDto>> DoneWorking(int workingId)
    {
        var working = await _workingRepository.GetByIdAsync(workingId);
        if (working is not null)
        {
            working.Status = true;
            var result = await _unitOfWork.CommitAsync();
            if (result > 0)
                return new Response<WorkingUpdateDto>(ResponseType.Success);
            return new Response<WorkingUpdateDto>(ResponseType.SaveError, "Güncelleme olmadı.");
        }
        return new Response<WorkingUpdateDto>(ResponseType.NotFound, "İş bulunamdı");
    }

    public async Task<IResponse<List<WorkingTableListDto>>> GetAllTableCompleteAsync(int appUserId)
    {
        var workingTableList = await _workingRepository
                           .GetAllTableCompleteAsync(appUserId);

        var dto = _mapper.Map<List<WorkingTableListDto>>(workingTableList);
        return new Response<List<WorkingTableListDto>>(ResponseType.Success, dto);
    }

    public async Task<int> GetNumberOfReportsWrittenAsync(int appUserId)
        => await _workingRepository.GetNumberOfReportsWrittenAsync(appUserId);

    public async Task<int> GetNumberOfTasksCompletedAsync(int appUserId)
        => await _workingRepository.GetNumberOfTasksCompletedAsync(appUserId);

    public async Task<int> GetNumberOfTaskToCompleteAsync(int appUserId)
        => await _workingRepository.GetNumberOfTaskToCompleteAsync(appUserId);

    public async Task<IResponse<List<GraphicListDto>>> MostCompletedStaffAsync()
    {
        var data = await _workingRepository.MostCompletedStaffAsync();
        if (data is not null)
            return new Response<List<GraphicListDto>>(ResponseType.Success, data);
        return new Response<List<GraphicListDto>>(ResponseType.NotFound, "Data bulunamadı");
    }

    public async Task<IResponse<List<GraphicListDto>>> MostEmployedStaffAsync()
    {
        var data = await _workingRepository.MostEmployedStaffAsync();
        if (data is not null)
            return new Response<List<GraphicListDto>>(ResponseType.Success, data);
        return new Response<List<GraphicListDto>>(ResponseType.NotFound, "Data bulunamadı");
    }

    public async Task<int> GetNumberOfTaskPendingAssignmentAsync()
    {
        return await _workingRepository
            .GetCountAsync(x => x.AppUser == null);
    }

    public async Task<int> GetNumberOfCompletedTaskAsync()
    {
        return await _workingRepository
            .GetCountAsync(x => x.Status);
    }
}
