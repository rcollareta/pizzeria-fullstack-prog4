# Pizzería 5G - Proyecto Fullstack

Proyecto práctico de Programación IV desarrollado con arquitectura cliente-servidor.

El sistema permite visualizar un menú de pizzas, iniciar sesión con roles, administrar pizzas desde un panel de administrador y ver estadísticas simples.

---

## Tecnologías utilizadas

### Backend

- ASP.NET Core Web API
- Entity Framework Core
- SQL Server LocalDB
- JWT
- Swagger
- Arquitectura Onion
- Repository Pattern
- DTOs
- Inyección de dependencias

### Frontend

- React
- Vite
- Wouter
- Axios
- Zustand
- Zod
- React Hook Form
- React.lazy + Suspense

---

## Arquitectura del backend

El backend está dividido en capas:

- `Pizzeria.Domain`: entidades del dominio.
- `Pizzeria.Application`: DTOs, interfaces y servicios.
- `Pizzeria.Infrastructure`: DbContext y repositories.
- `Pizzeria.API`: controllers, configuración, Swagger y JWT.

Flujo utilizado:

```text
Controller → Service → Repository → DbContext → SQL Server