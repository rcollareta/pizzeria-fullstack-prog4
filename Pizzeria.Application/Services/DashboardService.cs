using Pizzeria.Application.DTOs;
using Pizzeria.Application.Interfaces;

namespace Pizzeria.Application.Services;

public class DashboardService : IDashboardService
{
    private readonly IDashboardRepository _dashboardRepository;

    public DashboardService(IDashboardRepository dashboardRepository)
    {
        _dashboardRepository = dashboardRepository;
    }

    public async Task<DashboardDto> ObtenerDashboard()
    {
        return await _dashboardRepository.ObtenerDashboard();
    }
}