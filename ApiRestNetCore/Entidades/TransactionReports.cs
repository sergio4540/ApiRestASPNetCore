using System.ComponentModel.DataAnnotations;

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
    }
}
