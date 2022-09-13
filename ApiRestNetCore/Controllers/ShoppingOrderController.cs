using ApiRestNetCore.Data;
using ApiRestNetCore.DTOs;
using ApiRestNetCore.Entidades;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiRestNetCore.Controllers
{
    [ApiController]
    [Route("api/shopping")]
    public class ShoppingOrderController : Controller
    {
        private readonly ILogger<ShoppingOrderController> logger;
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public ShoppingOrderController(ILogger<ShoppingOrderController> logger, ApplicationDbContext context, IMapper mapper)
        {
            this.logger = logger;
            this.context = context;
            this.mapper = mapper;
        }


        //Select * from genero
        [HttpGet]
        public async Task<ActionResult<List<ShoppingOrder>>> Get()
        {

            return await context.ShoppingOrder.ToListAsync();


        }

        // Búsqueda por parámetro
        [HttpGet("{id:int}")]
        public async Task<ActionResult<ShoppingOrderDTO>> Get(int id)
        {

            var shoppingOrder = await context.ShoppingOrder.FirstOrDefaultAsync(x => x.OrderId == id);


            if (shoppingOrder == null)
            {


                return NotFound();
            }


            return mapper.Map<ShoppingOrderDTO>(shoppingOrder);

        }


        [HttpPost]

        public async Task<ActionResult> Post([FromBody] ShoppingOrderCreacionDTO shoppingOrderCreacionDTO)
        {


            var shopping = mapper.Map<Categories>(shoppingOrderCreacionDTO);
            context.Add(shopping);
            await context.SaveChangesAsync();
            return NoContent(); //204


        }



        [HttpPut("{id}")]

        public async Task<ActionResult> Put(ShoppingOrder shopping, int id)
        {

            if (shopping.OrderId != id)
            {
                return BadRequest("la shopping no existe");
            }

            var existe = await context.ShoppingOrder.AnyAsync(x => x.OrderId == id);

            if (!existe)
            {

                return NotFound();



            }

            context.Update(shopping);
            await context.SaveChangesAsync();
            return Ok(); //200


        }


        [HttpDelete("{id}")]

        public async Task<ActionResult> Delete(int id)
        {


            var shopping = await context.ShoppingOrder.FirstOrDefaultAsync(x => x.OrderId == id);

            if (shopping == null)
            {

                return NotFound();
            }

            context.Remove(shopping);
            await context.SaveChangesAsync();
            return NoContent(); //204


        }
    }
}
