using Microsoft.EntityFrameworkCore;
using Pizzeria.Application.DTOs;
using Pizzeria.Application.Interfaces;
using Pizzeria.Infrastructure.Data;

namespace Pizzeria.Infrastructure.Repositories;

public class DashboardRepository : IDashboardRepository
{
    private readonly PizzeriaDbContext _context;

    public DashboardRepository(PizzeriaDbContext context)
    {
        _context = context;
    }

    public async Task<DashboardDto> ObtenerDashboard()
    {
        decimal pizzaMasCara = 0;

        if (await _context.Pizzas.AnyAsync())
        {
            pizzaMasCara = await _context.Pizzas.MaxAsync(p => p.Precio);
        }

        return new DashboardDto
        {
            TotalPizzas = await _context.Pizzas.CountAsync(),
            TotalUsuarios = await _context.Usuarios.CountAsync(),
            PizzaMasCara = pizzaMasCara
        };
    }
}