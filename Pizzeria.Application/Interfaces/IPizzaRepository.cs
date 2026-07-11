using Pizzeria.Domain.Entities;

namespace Pizzeria.Application.Interfaces;

public interface IPizzaRepository
{
    Task<List<Pizza>> GetAllAsync();

    Task<Pizza?> GetByIdAsync(int id);

    Task AddAsync(Pizza pizza);

    Task UpdateAsync(Pizza pizza);

    Task DeleteAsync(Pizza pizza);
}