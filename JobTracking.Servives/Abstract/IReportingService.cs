using JobTracking.Common.Abstract;
using JobTracking.Dtos.ReportingDtos;

namespace JobTracking.Services.Abstract;

public interface IReportingService
{
    Task<IResponse<List<ReportingListDto>>> GetAllByWorkingIdAsync(int workingId);
    Task<IResponse<ReportingCreateDto>> CreateReport(ReportingCreateDto dto);
}
