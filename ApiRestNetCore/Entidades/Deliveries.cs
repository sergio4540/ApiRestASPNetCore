using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiRestNetCore.Entidades
{
    public class Deliveries
    {
        [Key]
        public int DeliveriesId { get; set; }
        public int CustomerId { get; set; }
        public DateTime Date { get; set; }

        // PROPIEDAD DE NAVEGACIÓN
        [ForeignKey("CustomerId")]
        public Customer ?Customer { get; set; }
    }
}
