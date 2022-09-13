using System.ComponentModel.DataAnnotations;

namespace ApiRestNetCore.Entidades
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }

        [Required]

        [StringLength(50)]
        public string ?Name { get; set; }
        [StringLength(50)]
        public string ?ContactAdd { get; set; }
        [StringLength(50)]
        public string ?Address { get; set; }

        // PROPIEDAD DE NAVEGACIÓN
        public ICollection<Deliveries> ?Deliveries { get; set; }
        public ICollection<ShoppingOrder> ?ShoppingOrders { get; set; }
    }
}
