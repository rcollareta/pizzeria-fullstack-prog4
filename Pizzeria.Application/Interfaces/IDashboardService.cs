using Pizzeria.Application.DTOs;

namespace Pizzeria.Application.Interfaces;

public interface IDashboardService
{
    Task<DashboardDto> ObtenerDashboard();
}