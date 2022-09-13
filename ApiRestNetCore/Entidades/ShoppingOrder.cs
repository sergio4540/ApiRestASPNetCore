﻿using System.ComponentModel.DataAnnotations;

namespace ApiRestNetCore.Entidades
{
    public class ShoppingOrder
    {
        [Key]
        public int OrderId { get; set; }

        public int CustomerId { get; set; }
        [StringLength(50)]
        public DateTime Date { get; set; }
    }
}