﻿using ApiRestNetCore.Entidades;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiRestNetCore.DTOs
{
    public class ProductCreacionDTO
    {
        public int CategotyId { get; set; }
        [StringLength(50)]
        public string? ProductName { get; set; }
        // PROPIEDAD DE NAVEGACIÓN
        [ForeignKey("CategoryId")]
        public Categories Categories { get; set; }
    }
}
