using AutoMapper;
using JobTracking.Common.Abstract;
using JobTracking.Common.ComplextTypes;
using JobTracking.Common.ResponseObjects;
using JobTracking.Dtos.WorkingDtos;
using JobTracking.Entities.Models;
using JobTracking.Repositories.Abstract;
using JobTracking.Servives.Abstract;
using Microsoft.EntityFrameworkCore;

namespace JobTracking.Servives.Manager;

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
        var data = await _workingRepository.CreateAsync(working);
        var result = await _unitOfWork.CommitAsync();
        if (result > 0)
        {
            var workingDto = _mapper.Map<WorkingCreateDto>(data);
            return new Response<WorkingCreateDto>(ResponseType.Success, workingDto);
        }
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

    public async Task<IResponse<List<WorkingListDto>>> GetAllWithCategoryAsync()
    {
        var workingList = await _workingRepository.GetAllWithCategoryAsync();
        var workingDto = _mapper.Map<List<WorkingListDto>>(workingList);
        return new Response<List<WorkingListDto>>(ResponseType.Success, workingDto);
    }

    public async Task<IResponse<WorkingListDto>> GetByIdAsync(int id)
    {
        var working = await _workingRepository.GetByIdAsync(id);
        if (working is null)
            return new Response<WorkingListDto>(ResponseType.NotFound, "İş bulunamadı");

        var workingDto = _mapper.Map<WorkingListDto>(working);
        return new Response<WorkingListDto>(ResponseType.Success, workingDto);
    }

    public async Task<IResponse<WorkingUpdateDto>> UpdateAsync(WorkingUpdateDto dto)
    {
        var updatedEntity = await _workingRepository.GetByIdAsync(dto.Id);
        if (updatedEntity is not null)
        {
            var working = _mapper.Map<Working>(dto);
            working.CreatedDate = updatedEntity.CreatedDate;
            _workingRepository.Update(working, updatedEntity);
            var result = await _unitOfWork.CommitAsync();
            if (result > 0)
                return new Response<WorkingUpdateDto>(ResponseType.Success);
            return new Response<WorkingUpdateDto>(ResponseType.SaveError, "Kayıt sırasında hata oluştu");
        }
        return new Response<WorkingUpdateDto>(ResponseType.NotFound, "İş bulunamdı");
    }
}
