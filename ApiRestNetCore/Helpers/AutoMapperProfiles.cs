using AutoMapper;
using ApiRestNetCore.DTOs;
using ApiRestNetCore.Entidades;

namespace ApiRestNetCore.Helpers
{
    public class AutoMapperProfiles: Profile
    {

        public AutoMapperProfiles()
        {


          
            CreateMap<Customer,CustomerDTO >().ReverseMap();
            CreateMap<CustomerCreacionDTO, Customer>();

            CreateMap<Product, ProductDTO>().ReverseMap();
            CreateMap<ProductCreacionDTO, Product>();

            CreateMap<Categories, CategoriesDTO>().ReverseMap();
            CreateMap<CategoriesCreacionDTO, Categories>();

            CreateMap<Deliveries, DeliveriesDTO>().ReverseMap();
            CreateMap<DeliveriesCreacionDTO, Deliveries>();

            CreateMap<Payment, PaymentDTO>().ReverseMap();
            CreateMap<PaymentCreacionDTO, Payment>();

            CreateMap<Seller, SellerDTO>().ReverseMap();
            CreateMap<SellerCreacionDTO, Seller>();

            CreateMap<ShoppingOrder, ShoppingOrderDTO>().ReverseMap();
            CreateMap<ShoppingOrderCreacionDTO, ShoppingOrder>();

            CreateMap<TransactionReports, TransactionReportsDTO>().ReverseMap();
            CreateMap<TransactionReportsCreacionDTO, TransactionReports>();


        }







    }
}
