using Microsoft.AspNetCore.Mvc;
using Pizzeria.Application.DTOs;
using Pizzeria.Application.Interfaces;

namespace Pizzeria.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequestDto request)
    {
        var usuario = await _authService.Login(request);

        if (usuario == null)
            return Unauthorized("Email o contraseña incorrectos.");

        return Ok(usuario);
    }
}