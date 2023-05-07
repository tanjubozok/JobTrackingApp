using AutoMapper;
using JobTracking.Common.Abstract;
using JobTracking.Common.ComplextTypes;
using JobTracking.Common.ResponseObjects;
using JobTracking.Dtos.ReportingDtos;
using JobTracking.Entities.Models;
using JobTracking.Repositories.Abstract;
using JobTracking.Services.Abstract;

namespace JobTracking.Services.Manager;

public class ReportingManager : IReportingService
{
    private readonly IReportingRepository _reportingRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public ReportingManager(IReportingRepository reportingRepository, IUnitOfWork unitOfWork, IMapper mapper)
    {
        _reportingRepository = reportingRepository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<IResponse<ReportingCreateDto>> CreateReport(ReportingCreateDto dto)
    {
        var report = _mapper.Map<Reporting>(dto);
        await _reportingRepository.CreateAsync(report);
        var result = await _unitOfWork.CommitAsync();
        if (result > 0)
            return new Response<ReportingCreateDto>(ResponseType.Success, dto);
        return new Response<ReportingCreateDto>(ResponseType.SaveError, "Kayıt sırasında hata oluştu");
    }

    public async Task<IResponse<ReportingEditDto>> EditReport(ReportingEditDto dto)
    {
        var report = await _reportingRepository.GetByIdAsync(dto.Id);
        if (report is null)
            return new Response<ReportingEditDto>(ResponseType.NotFound, "Rapor bulunamadı");
        var updatedData = _mapper.Map<Reporting>(dto);
        _reportingRepository.Update(updatedData, report);
        var result = await _unitOfWork.CommitAsync();
        if (result > 0)
            return new Response<ReportingEditDto>(ResponseType.Success, dto);
        return new Response<ReportingEditDto>(ResponseType.SaveError, "Kayıt sırasında hata oluştu");
    }

    public async Task<IResponse<List<ReportingListDto>>> GetAllByWorkingIdAsync(int workingId)
    {
        var list = await _reportingRepository.GetAllByWorkingIdAsync(workingId);
        var dto = _mapper.Map<List<ReportingListDto>>(list);

        return new Response<List<ReportingListDto>>(ResponseType.Success, dto);
    }

    public async Task<IResponse<ReportingEditDto>> GetById(int id)
    {
        var report = await _reportingRepository.GetByIdAsync(id);
        if (report is null)
            return new Response<ReportingEditDto>(ResponseType.NotFound, $"{id} bulunamadı");

        var dto = _mapper.Map<ReportingEditDto>(report);
        return new Response<ReportingEditDto>(ResponseType.Success, dto);
    }
}