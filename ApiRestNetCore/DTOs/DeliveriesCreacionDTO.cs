using ApiRestNetCore.Entidades;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiRestNetCore.DTOs
{
    public class DeliveriesCreacionDTO
    {
        public int CustomerId { get; set; }
        public DateTime Date { get; set; }

        // PROPIEDAD DE NAVEGACIÓN
        [ForeignKey("CustomerId")]
        public Customer? Customer { get; set; }
    }
}
