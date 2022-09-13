using ApiRestNetCore.Entidades;
using System.ComponentModel.DataAnnotations;

namespace ApiRestNetCore.DTOs
{
    public class CategoriesCreacionDTO
    {
        [Required]

        [StringLength(50)]
        public string? CategoryName { get; set; }
        [StringLength(50)]
        public string? CategoryType { get; set; }
        // PROPIEDAD DE NAVEGACIÓN
        public ICollection<Product> Product { get; set; }
    }
}
