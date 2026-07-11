using Microsoft.EntityFrameworkCore;
using Pizzeria.Application.Interfaces;
using Pizzeria.Domain.Entities;
using Pizzeria.Infrastructure.Data;

namespace Pizzeria.Infrastructure.Repositories;

public class AuthRepository : IAuthRepository
{
    private readonly PizzeriaDbContext _context;

    public AuthRepository(PizzeriaDbContext context)
    {
        _context = context;
    }

    public async Task<Usuario?> LoginAsync(string email, string password)
    {
        return await _context.Usuarios
            .FirstOrDefaultAsync(x => x.Email == email && x.Password == password);
    }
}