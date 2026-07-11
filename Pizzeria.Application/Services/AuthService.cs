using Pizzeria.Application.DTOs;
using Pizzeria.Application.Interfaces;

namespace Pizzeria.Application.Services;

public class AuthService : IAuthService
{
    private readonly IAuthRepository _authRepository;
    private readonly IJwtService _jwtService;

    public AuthService(IAuthRepository authRepository, IJwtService jwtService)
    {
        _authRepository = authRepository;
        _jwtService = jwtService;
    }

    public async Task<LoginResponseDto?> Login(LoginRequestDto request)
    {
        var usuario = await _authRepository.LoginAsync(request.Email, request.Password);

        if (usuario == null)
            return null;

        var token = _jwtService.GenerarToken(usuario);

        return new LoginResponseDto
        {
            Nombre = usuario.Nombre,
            Rol = usuario.Rol,
            Token = token
        };
    }
}