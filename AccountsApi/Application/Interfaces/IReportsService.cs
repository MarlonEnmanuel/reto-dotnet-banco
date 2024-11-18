using AccountsApi.Application.Dtos;

namespace AccountsApi.Application.Interfaces
{
    public interface IReportsService
    {
        Task<List<ReportDetailDto>> GetReport(ReportQueryDto query);
    }
}