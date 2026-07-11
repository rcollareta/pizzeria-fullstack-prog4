using Pizzeria.Application.DTOs;

namespace Pizzeria.Application.Interfaces;

public interface IAuthService
{
    Task<LoginResponseDto?> Login(LoginRequestDto request);
}