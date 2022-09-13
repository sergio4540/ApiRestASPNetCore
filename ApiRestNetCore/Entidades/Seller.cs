using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ApiRestNetCore.Entidades
{
    public class Seller
    {
        [Key]
        public int SellerId { get; set; }
        [StringLength(50)]
        public string? Name { get; set; }


        public ICollection<ProductSeller>? ProductSellers { get; set; }
    }
}
