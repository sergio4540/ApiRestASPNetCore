using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ApiRestNetCore.Entidades
{
    public class Payment
    {
        [Key]
        public int PaymentId { get; set; }

        public int ClienteId { get; set; }
        public DateTime Date { get; set; }

        // PROPIEDAD DE NAVEGACIÓN
        [ForeignKey("ClienteId")]
        public Customer? Customer { get; set; }
    }
}
