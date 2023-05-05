using JobTracking.Common.Abstract;
using JobTracking.Dtos.ReportingDtos;

namespace JobTracking.Servives.Abstract;

public interface IReportingService
{
    Task<IResponse<List<ReportingListDto>>> GetAllByWorkingIdAsync(int workingId);
    Task<IResponse<ReportingCreateDto>> CreateReport(ReportingCreateDto dto);
}
