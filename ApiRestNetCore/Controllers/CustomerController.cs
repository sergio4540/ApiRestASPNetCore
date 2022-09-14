using ApiRestNetCore.DTOs;
using ApiRestNetCore.Entidades;
using AutoMapper;
using ApiRestNetCore.Controllers;
using ApiRestNetCore.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiRestNetCore.Servicios;

namespace ApiRestNetCore.Controllers
{
    [ApiController]
    [Route("api/customer")]
    public class CustomerController:Controller
    {
        private readonly ILogger<CustomerController> logger;
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;
        private readonly IAlmacenadorArchivos almacenadorArchivos;
        private readonly string contenedor = "Files";

        public CustomerController(ILogger<CustomerController> logger, ApplicationDbContext context, IMapper mapper,
             IAlmacenadorArchivos almacenadorArchivos)
        {
            this.logger = logger;
            this.context = context;
            this.mapper = mapper;
            this.almacenadorArchivos = almacenadorArchivos;
        }


        //Select * from genero
        [HttpGet]
        public async Task<ActionResult<List<Customer>>> Get()
        {

            return await context.Customer.ToListAsync();


        }

        // Búsqueda por parámetro
        [HttpGet("{id:int}")]
        public async Task<ActionResult<CustomerDTO>> Get(int id)
        {

            var genero = await context.Customer.FirstOrDefaultAsync(x => x.CustomerId == id);


            if (genero == null)
            {


                return NotFound();
            }


            return mapper.Map<CustomerDTO>(genero);

        }


        [HttpPost]

        public async Task<ActionResult> Post([FromForm] CustomerCreacionDTO customerCreacionDTO)
        {

            var archivos = mapper.Map<Customer>(customerCreacionDTO);

            if (customerCreacionDTO.Foto != null)
            {

                archivos.Foto = await almacenadorArchivos.GuardarArchivo(contenedor, customerCreacionDTO.Foto);

            }


            context.Add(archivos);
            await context.SaveChangesAsync();

            return NoContent();




        }



        [HttpPut("{id}")]

        public async Task<ActionResult> Put(Customer customer, int id)
        {

            if (customer.CustomerId != id)
            {
                return BadRequest("El genero no existe");
            }

            var existe = await context.Customer.AnyAsync(x => x.CustomerId == id);

            if (!existe)
            {

                return NotFound();



            }

            context.Update(customer);
            await context.SaveChangesAsync();
            return Ok(); //200


        }


        [HttpDelete("{id}")]

        public async Task<ActionResult> Delete(int id)
        {


            var genero = await context.Customer.FirstOrDefaultAsync(x => x.CustomerId == id);

            if (genero == null)
            {

                return NotFound();
            }

            context.Remove(genero);
            await context.SaveChangesAsync();
            return NoContent(); //204


        }
    }
}
