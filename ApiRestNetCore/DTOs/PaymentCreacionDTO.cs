using ApiRestNetCore.Entidades;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiRestNetCore.DTOs
{
    public class PaymentCreacionDTO
    {
        public int ClienteId { get; set; }
        public DateTime Date { get; set; }
        // PROPIEDAD DE NAVEGACIÓN
        [ForeignKey("ClienteId")]
        public Customer? Customer { get; set; }
    }
}
