using Pizzeria.Application.DTOs;
using Pizzeria.Application.Interfaces;
using Pizzeria.Domain.Entities;

namespace Pizzeria.Application.Services;

public class PizzaService : IPizzaService
{
    private readonly IPizzaRepository _pizzaRepository;

    public PizzaService(IPizzaRepository pizzaRepository)
    {
        _pizzaRepository = pizzaRepository;
    }

    public async Task<List<PizzaResponseDto>> GetAll()
    {
        var pizzas = await _pizzaRepository.GetAllAsync();

        return pizzas.Select(p => new PizzaResponseDto
        {
            Id = p.Id,
            Nombre = p.Nombre,
            Descripcion = p.Descripcion,
            Precio = p.Precio,
            Categoria = p.Categoria,
            ImagenUrl = p.ImagenUrl
        }).ToList();
    }

    public async Task<PizzaResponseDto?> GetById(int id)
    {
        var pizza = await _pizzaRepository.GetByIdAsync(id);

        if (pizza == null)
            return null;

        return new PizzaResponseDto
        {
            Id = pizza.Id,
            Nombre = pizza.Nombre,
            Descripcion = pizza.Descripcion,
            Precio = pizza.Precio,
            Categoria = pizza.Categoria,
            ImagenUrl = pizza.ImagenUrl
        };
    }

    public async Task<PizzaResponseDto> Create(PizzaCreateDto dto)
    {
        var pizza = new Pizza
        {
            Nombre = dto.Nombre,
            Descripcion = dto.Descripcion,
            Precio = dto.Precio,
            Categoria = dto.Categoria,
            ImagenUrl = dto.ImagenUrl
        };

        await _pizzaRepository.AddAsync(pizza);

        return new PizzaResponseDto
        {
            Id = pizza.Id,
            Nombre = pizza.Nombre,
            Descripcion = pizza.Descripcion,
            Precio = pizza.Precio,
            Categoria = pizza.Categoria,
            ImagenUrl = pizza.ImagenUrl
        };
    }

    public async Task<PizzaResponseDto?> Update(int id, PizzaUpdateDto dto)
    {
        var pizza = await _pizzaRepository.GetByIdAsync(id);

        if (pizza == null)
            return null;

        pizza.Nombre = dto.Nombre;
        pizza.Descripcion = dto.Descripcion;
        pizza.Precio = dto.Precio;
        pizza.Categoria = dto.Categoria;
        pizza.ImagenUrl = dto.ImagenUrl;

        await _pizzaRepository.UpdateAsync(pizza);

        return new PizzaResponseDto
        {
            Id = pizza.Id,
            Nombre = pizza.Nombre,
            Descripcion = pizza.Descripcion,
            Precio = pizza.Precio,
            Categoria = pizza.Categoria,
            ImagenUrl = pizza.ImagenUrl
        };
    }

    public async Task<bool> Delete(int id)
    {
        var pizza = await _pizzaRepository.GetByIdAsync(id);

        if (pizza == null)
            return false;

        await _pizzaRepository.DeleteAsync(pizza);

        return true;
    }
}