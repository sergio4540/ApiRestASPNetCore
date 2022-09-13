using ApiRestNetCore.Entidades;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ApiRestNetCore.DTOs
{
    public class SellerCreacionDTO
    {
        public int ProductId { get; set; }
        [StringLength(50)]
        public string? Name { get; set; }

        // PROPIEDAD DE NAVEGACIÓN
        [ForeignKey("ProductId")]
        public Categories ?Products { get; set; }
    }
}
