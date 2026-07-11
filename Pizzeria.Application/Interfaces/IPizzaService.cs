using Pizzeria.Application.DTOs;

namespace Pizzeria.Application.Interfaces;

public interface IPizzaService
{
    Task<List<PizzaResponseDto>> GetAll();

    Task<PizzaResponseDto?> GetById(int id);

    Task<PizzaResponseDto> Create(PizzaCreateDto dto);

    Task<PizzaResponseDto?> Update(int id, PizzaUpdateDto dto);

    Task<bool> Delete(int id);
}