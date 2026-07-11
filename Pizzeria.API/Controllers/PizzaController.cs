using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Pizzeria.Application.DTOs;
using Pizzeria.Application.Interfaces;

namespace Pizzeria.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PizzaController : ControllerBase
{
    private readonly IPizzaService _pizzaService;

    public PizzaController(IPizzaService pizzaService)
    {
        _pizzaService = pizzaService;
    }

    [HttpGet]
    [AllowAnonymous]
    public async Task<ActionResult<List<PizzaResponseDto>>> GetAll()
    {
        return Ok(await _pizzaService.GetAll());
    }

    [HttpGet("{id}")]
    [AllowAnonymous]
    public async Task<ActionResult<PizzaResponseDto>> GetById(int id)
    {
        var pizza = await _pizzaService.GetById(id);

        if (pizza == null)
            return NotFound();

        return Ok(pizza);
    }

    [HttpPost]
    [Authorize(Roles = "Admin")]
    public async Task<ActionResult<PizzaResponseDto>> Create(PizzaCreateDto dto)
    {
        var pizza = await _pizzaService.Create(dto);

        return CreatedAtAction(nameof(GetById), new { id = pizza.Id }, pizza);
    }

    [HttpPut("{id}")]
    [Authorize(Roles = "Admin")]
    public async Task<ActionResult<PizzaResponseDto>> Update(int id, PizzaUpdateDto dto)
    {
        var pizza = await _pizzaService.Update(id, dto);

        if (pizza == null)
            return NotFound();

        return Ok(pizza);
    }

    [HttpDelete("{id}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Delete(int id)
    {
        var eliminado = await _pizzaService.Delete(id);

        if (!eliminado)
            return NotFound();

        return NoContent();
    }
}