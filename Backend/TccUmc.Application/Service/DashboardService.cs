using TccUmc.Application.DTO;
using TccUmc.Application.IService;
using TccUmc.Infrastructure.IRepository;

namespace TccUmc.Application.Service;

public class DasboardService : IDashboardService
{
    public IDashboardRepository _dashboardRepository;

    public DasboardService(IDashboardRepository dashboardRepository)
    {
        _dashboardRepository = dashboardRepository;
    }

    public async Task<DashboardGetDto> GetDashboard(string getHttpContextId)
    {
        return new DashboardGetDto()
        {

        };
    }
}