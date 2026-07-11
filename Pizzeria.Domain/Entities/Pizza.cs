using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizzeria.Domain.Entities;

public class Pizza
{
    public int Id { get; set; }

    public string Nombre { get; set; } = string.Empty;

    public string Descripcion { get; set; } = string.Empty;

    public decimal Precio { get; set; }

    public string Categoria { get; set; } = string.Empty;

    public string ImagenUrl { get; set; } = string.Empty;
}