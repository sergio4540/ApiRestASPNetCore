using System.ComponentModel.DataAnnotations;

namespace ApiRestNetCore.Entidades
{
    public class Categories
    {
        [Key]
        public int CategoryId { get; set; }

        [Required]

        [StringLength(50)]
        public string? CategoryName { get; set; }
        [StringLength(50)]
        public string? CategoryType { get; set; }

        // PROPIEDAD DE NAVEGACIÓN
        public ICollection<Product> ?Product { get; set; }
    }
}
