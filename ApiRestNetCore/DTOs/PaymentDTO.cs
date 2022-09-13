using System.ComponentModel.DataAnnotations;

namespace ApiRestNetCore.DTOs
{
    public class PaymentDTO
    {
        [Key]
        public int PaymentId { get; set; }

        public int CategoryId { get; set; }
        public DateTime Date { get; set; }
    }
}
