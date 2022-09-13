using ApiRestNetCore.Entidades;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiRestNetCore.DTOs
{
    public class TransactionReportsDTO
    {
        [Key]
        public int TransactionReportId { get; set; }

        public int ProductId { get; set; }
        public int OrderId { get; set; }

        // PROPIEDAD DE NAVEGACIÓN
        [ForeignKey("ProductId")]
        public Product? Product { get; set; }

        [ForeignKey("OrderId")]
        public ShoppingOrder? ShoppingOrder { get; set; }
    }
}
