using System.ComponentModel.DataAnnotations;

namespace ApiRestNetCore.DTOs
{
    public class ShoppingOrderCreacionDTO
    {
        public int CustomerId { get; set; }
        [StringLength(50)]
        public DateTime Date { get; set; }
    }
}
