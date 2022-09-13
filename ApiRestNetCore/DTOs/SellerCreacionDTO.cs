using ApiRestNetCore.Entidades;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ApiRestNetCore.DTOs
{
    public class SellerCreacionDTO
    {
        [StringLength(50)]
        public string? Name { get; set; }

        public ICollection<ProductSeller>? ProductSeller { get; set; }
    }
}
