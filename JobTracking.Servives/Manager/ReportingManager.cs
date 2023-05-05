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
        var addedData = await _reportingRepository.CreateAsync(report);
        var result = await _unitOfWork.CommitAsync();
        if (result > 0)
        {
            var reportDto = _mapper.Map<ReportingCreateDto>(addedData);
            return new Response<ReportingCreateDto>(ResponseType.Success, reportDto);
        }
        return new Response<ReportingCreateDto>(ResponseType.SaveError, "Kayıt sırasında hata oluştu");
    }

    public async Task<IResponse<List<ReportingListDto>>> GetAllByWorkingIdAsync(int workingId)
    {
        var list = await _reportingRepository.GetAllByWorkingIdAsync(workingId);
        var dto = _mapper.Map<List<ReportingListDto>>(list);

        return new Response<List<ReportingListDto>>(ResponseType.Success, dto);
    }
}