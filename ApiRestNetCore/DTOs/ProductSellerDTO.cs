using ApiRestNetCore.Entidades;
using System.ComponentModel.DataAnnotations;

namespace ApiRestNetCore.DTOs
{
    public class ProductSellerDTO
    {
        public int ProductId { get; set; }
        public int SellerId { get; set; }

        public Product ?Product { get; set; }
        public Seller ?Seller { get; set; }
    }
}
