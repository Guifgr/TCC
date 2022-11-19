using AutoMapper;
using TccUmc.Application.DTO;
using TccUmc.Application.IService;
using TccUmc.Infrastructure.IRepository;

namespace TccUmc.Application.Service;

public class DashboardService : IDashboardService
{
    private readonly IDashboardRepository _dashboardRepository;
    private readonly IMapper _mapper;
    public DashboardService(IDashboardRepository dashboardRepository, IMapper mapper)
    {
        _dashboardRepository = dashboardRepository;
        _mapper = mapper;
    }

    public async Task<DashboardGetDto> GetDashboard(string userId)
    {
        return _mapper.Map<DashboardGetDto>(await _dashboardRepository.GetDashboard(int.Parse(userId)));
    }
}