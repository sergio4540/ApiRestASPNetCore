using System.ComponentModel.DataAnnotations;

namespace ApiRestNetCore.Entidades
{
    public class Deliveries
    {
        [Key]
        public int DeliveriesId { get; set; }
        public int CustomerId { get; set; }
        public DateTime Date { get; set; }
    }
}
