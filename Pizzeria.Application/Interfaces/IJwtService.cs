using Pizzeria.Domain.Entities;

namespace Pizzeria.Application.Interfaces;

public interface IJwtService
{
    string GenerarToken(Usuario usuario);
}