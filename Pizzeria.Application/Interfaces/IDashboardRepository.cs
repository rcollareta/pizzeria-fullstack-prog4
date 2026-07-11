using Pizzeria.Application.DTOs;

namespace Pizzeria.Application.Interfaces;

public interface IDashboardRepository
{
    Task<DashboardDto> ObtenerDashboard();
}