using Pizzeria.Domain.Entities;

namespace Pizzeria.Application.Interfaces;

public interface IAuthRepository
{
    Task<Usuario?> LoginAsync(string email, string password);
}