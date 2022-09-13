using ApiRestNetCore.Entidades;

namespace ApiRestNetCore.DTOs
{
    public class ProductSellerCreacionDTO
    {
        public Product? Product { get; set; }
        public Seller? Seller { get; set; }
    }
}
