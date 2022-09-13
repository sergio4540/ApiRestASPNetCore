using System.ComponentModel.DataAnnotations;

namespace ApiRestNetCore.DTOs
{
    public class DeliveriesDTO
    {
        [Key]
        public int DeliveriesId { get; set; }
        public int CustomerId { get; set; }
        public DateTime Date { get; set; }
    }
}
