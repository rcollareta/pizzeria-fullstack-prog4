using Microsoft.EntityFrameworkCore;
using Pizzeria.Application.Interfaces;
using Pizzeria.Domain.Entities;
using Pizzeria.Infrastructure.Data;

namespace Pizzeria.Infrastructure.Repositories;

public class PizzaRepository : IPizzaRepository
{
    private readonly PizzeriaDbContext _context;

    public PizzaRepository(PizzeriaDbContext context)
    {
        _context = context;
    }

    public async Task<List<Pizza>> GetAllAsync()
    {
        return await _context.Pizzas.ToListAsync();
    }

    public async Task<Pizza?> GetByIdAsync(int id)
    {
        return await _context.Pizzas.FindAsync(id);
    }

    public async Task AddAsync(Pizza pizza)
    {
        await _context.Pizzas.AddAsync(pizza);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Pizza pizza)
    {
        _context.Pizzas.Update(pizza);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Pizza pizza)
    {
        _context.Pizzas.Remove(pizza);
        await _context.SaveChangesAsync();
    }
}