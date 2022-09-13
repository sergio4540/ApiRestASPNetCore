using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ApiRestNetCore.Entidades
{
    public class Payment
    {
        [Key]
        public int PaymentId { get; set; }

        public int CategoryId { get; set; }
        public DateTime Date { get; set; }
        public ICollection<TransactionReports>? TransactionReports { get; set; }
    }
}
