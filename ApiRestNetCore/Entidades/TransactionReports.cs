using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiRestNetCore.Entidades
{
    public class TransactionReports
    {
        [Key]
        public int ReportId { get; set; }

        public int CustomerId { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int PaymentId { get; set; }

        // PROPIEDAD DE NAVEGACIÓN
        [ForeignKey("CustomerId")]
        public Customer? Customer { get; set; }
        [ForeignKey("OrderId")]
        public ShoppingOrder? ShoppingOrder { get; set; }
        [ForeignKey("ProductId")]
        public Product? Product { get; set; }
        [ForeignKey("PaymentId")]
        public Payment? Payment { get; set; }
    }
}
