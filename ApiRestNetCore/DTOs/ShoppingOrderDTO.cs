using System.ComponentModel.DataAnnotations;

namespace ApiRestNetCore.DTOs
{
    public class ShoppingOrderDTO
    {
        [Key]
        public int OrderId { get; set; }

        public int CustomerId { get; set; }
        [StringLength(50)]
        public DateTime Date { get; set; }
    }
}
