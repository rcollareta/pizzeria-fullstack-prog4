using System.ComponentModel.DataAnnotations;

namespace Pizzeria.Application.DTOs;

public class PizzaCreateDto
{
    [Required]
    [StringLength(50)]
    public string Nombre { get; set; } = string.Empty;

    [Required]
    public string Descripcion { get; set; } = string.Empty;

    [Range(1, 100000)]
    public decimal Precio { get; set; }

    [Required]
    public string Categoria { get; set; } = string.Empty;

    public string ImagenUrl { get; set; } = string.Empty;
}