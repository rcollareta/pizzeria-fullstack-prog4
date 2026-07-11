using Microsoft.EntityFrameworkCore;
using Pizzeria.Domain.Entities;

namespace Pizzeria.Infrastructure.Data;

public class PizzeriaDbContext : DbContext
{
    public PizzeriaDbContext(DbContextOptions<PizzeriaDbContext> options)
        : base(options)
    {
    }

    public DbSet<Usuario> Usuarios { get; set; }

    public DbSet<Pizza> Pizzas { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Pizza>()
            .Property(p => p.Precio)
            .HasPrecision(18, 2);

        modelBuilder.Entity<Usuario>().HasData(
            new Usuario
            {
                Id = 1,
                Nombre = "Administrador",
                Email = "admin@pizzeria.com",
                Password = "123456",
                Rol = "Admin"
            },
            new Usuario
            {
                Id = 2,
                Nombre = "Usuario Demo",
                Email = "user@pizzeria.com",
                Password = "123456",
                Rol = "User"
            }
        );

        modelBuilder.Entity<Pizza>().HasData(
            new Pizza
            {
                Id = 1,
                Nombre = "Muzzarella",
                Descripcion = "Pizza clásica con salsa de tomate y queso muzzarella.",
                Precio = 5500,
                Categoria = "Clásica",
                ImagenUrl = "/img/muzzarella.jpg"
            },
            new Pizza
            {
                Id = 2,
                Nombre = "Napolitana",
                Descripcion = "Pizza con tomate, ajo, orégano y muzzarella.",
                Precio = 6500,
                Categoria = "Clásica",
                ImagenUrl = "/img/napolitana.jpg"
            },
            new Pizza
            {
                Id = 3,
                Nombre = "Especial",
                Descripcion = "Pizza con jamón, morrón y muzzarella.",
                Precio = 7500,
                Categoria = "Especial",
                ImagenUrl = "/img/especial.jpg"
            }
        );
    }
}