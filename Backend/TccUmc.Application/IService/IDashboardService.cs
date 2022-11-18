using TccUmc.Application.DTO;

namespace TccUmc.Application.IService;

public interface IDashboardService
{
    Task<DashboardGetDto> GetDashboard(string getHttpContextId);
}