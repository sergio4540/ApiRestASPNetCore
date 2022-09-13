using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiRestNetCore.Entidades
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        public int CategoryId { get; set; }
        [StringLength(50)]
        public string? ProductName { get; set; }

        // PROPIEDAD DE NAVEGACIÓN
        [ForeignKey("CategoryId")]
        public Categories ?Categories { get; set; }
        public ICollection<TransactionReports>? TransactionReports { get; set; }
    }
}
