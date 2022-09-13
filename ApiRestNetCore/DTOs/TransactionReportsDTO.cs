using System.ComponentModel.DataAnnotations;

namespace ApiRestNetCore.DTOs
{
    public class TransactionReportsDTO
    {
        [Key]
        public int ReportId { get; set; }

        public int CustomerId { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int PaymentId { get; set; }
    }
}
