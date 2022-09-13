﻿using System.ComponentModel.DataAnnotations;

namespace ApiRestNetCore.DTOs
{
    public class CustomerDTO
    {

        [Key]
        public int CustomerId { get; set; }

        [Required]

        [StringLength(50)]
        public string? Name { get; set; }
        [StringLength(50)]
        public string? ContactAdd { get; set; }
        [StringLength(50)]
        public string? Address { get; set; }

    }
}