using ApiRestNetCore.Data;
using ApiRestNetCore.DTOs;
using ApiRestNetCore.Entidades;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiRestNetCore.Controllers
{
    [ApiController]
    [Route("api/seller")]
    public class SellerController : Controller
    {
        private readonly ILogger<SellerController> logger;
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public SellerController(ILogger<SellerController> logger, ApplicationDbContext context, IMapper mapper)
        {
            this.logger = logger;
            this.context = context;
            this.mapper = mapper;
        }


        //Select * from genero
        [HttpGet]
        public async Task<ActionResult<List<Seller>>> Get()
        {

            return await context.Seller.ToListAsync();


        }

        // Búsqueda por parámetro
        [HttpGet("{id:int}")]
        public async Task<ActionResult<SellerDTO>> Get(int id)
        {

            var seller = await context.Seller.FirstOrDefaultAsync(x => x.SellerId == id);


            if (seller == null)
            {


                return NotFound();
            }


            return mapper.Map<SellerDTO>(seller);

        }


        [HttpPost]

        public async Task<ActionResult> Post([FromBody] SellerCreacionDTO sellerCreacionDTO)
        {


            var seller = mapper.Map<Product>(sellerCreacionDTO);
            context.Add(seller);
            await context.SaveChangesAsync();
            return NoContent(); //204


        }



        [HttpPut("{id}")]

        public async Task<ActionResult> Put(Seller seller, int id)
        {

            if (seller.SellerId != id)
            {
                return BadRequest("El producto no existe");
            }

            var existe = await context.Seller.AnyAsync(x => x.SellerId == id);

            if (!existe)
            {

                return NotFound();



            }

            context.Update(seller);
            await context.SaveChangesAsync();
            return Ok(); //200


        }


        [HttpDelete("{id}")]

        public async Task<ActionResult> Delete(int id)
        {


            var seller = await context.Seller.FirstOrDefaultAsync(x => x.SellerId == id);

            if (seller == null)
            {

                return NotFound();
            }

            context.Remove(seller);
            await context.SaveChangesAsync();
            return NoContent(); //204


        }
    }
}

