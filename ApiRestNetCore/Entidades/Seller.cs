using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ApiRestNetCore.Entidades
{
    public class Seller
    {
        [Key]
        public int SellerId { get; set; }

        public int ProductId { get; set; }
        [StringLength(50)]
        public string? Name { get; set; }

        // PROPIEDAD DE NAVEGACIÓN
        [ForeignKey("ProductId")]
        public Categories Products { get; set; }
    }
}
