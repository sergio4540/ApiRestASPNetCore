using ApiRestNetCore.Entidades;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiRestNetCore.DTOs
{
    public class ShoppingOrderCreacionDTO
    {
        public int CustomerId { get; set; }
        [StringLength(50)]
        public DateTime Date { get; set; }

        // PROPIEDAD DE NAVEGACIÓN
        [ForeignKey("CustomerId")]
        public Customer? Customer { get; set; }

        public ICollection<TransactionReports>? TransactionReports { get; set; }
    }
}
