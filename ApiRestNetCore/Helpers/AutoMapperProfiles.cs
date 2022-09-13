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



        }







    }
}
