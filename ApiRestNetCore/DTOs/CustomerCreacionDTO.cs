using System.ComponentModel.DataAnnotations;

namespace ApiRestNetCore.DTOs
{
    public class CustomerCreacionDTO
    {



        [Required]

        [StringLength(50)]
        public string? Name { get; set; }
        [StringLength(50)]
        public string? ContactAdd { get; set; }
        [StringLength(50)]
        public string? Address { get; set; }
    }
}
