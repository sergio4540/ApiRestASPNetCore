using ApiRestNetCore.Entidades;
using System.ComponentModel.DataAnnotations;

namespace ApiRestNetCore.DTOs
{
    public class PaymentCreacionDTO
    {
        public int CategoryId { get; set; }
        public DateTime Date { get; set; }
    }
}
