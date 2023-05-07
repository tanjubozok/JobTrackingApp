using JobTracking.Common.Abstract;
using JobTracking.Dtos.ReportingDtos;

namespace JobTracking.Services.Abstract;

public interface IReportingService
{
    Task<IResponse<ReportingCreateDto>> CreateReport(ReportingCreateDto dto);
    Task<IResponse<ReportingEditDto>> EditReport(ReportingEditDto dto);
    Task<IResponse<List<ReportingListDto>>> GetAllByWorkingIdAsync(int workingId);
    Task<IResponse<ReportingEditDto>> GetById(int id);
}
