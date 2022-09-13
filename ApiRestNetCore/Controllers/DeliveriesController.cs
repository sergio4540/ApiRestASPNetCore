using ApiRestNetCore.Data;
using ApiRestNetCore.DTOs;
using ApiRestNetCore.Entidades;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiRestNetCore.Controllers
{
    [ApiController]
    [Route("api/deliveries")]
    public class DeliveriesController : Controller
    {
        private readonly ILogger<DeliveriesController> logger;
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public DeliveriesController(ILogger<DeliveriesController> logger, ApplicationDbContext context, IMapper mapper)
        {
            this.logger = logger;
            this.context = context;
            this.mapper = mapper;
        }


        //Select * from genero
        [HttpGet]
        public async Task<ActionResult<List<Deliveries>>> Get()
        {

            return await context.Deliveries.ToListAsync();


        }

        // Búsqueda por parámetro
        [HttpGet("{id:int}")]
        public async Task<ActionResult<DeliveriesDTO>> Get(int id)
        {

            var deliveries = await context.Deliveries.FirstOrDefaultAsync(x => x.DeliveriesId == id);


            if (deliveries == null)
            {


                return NotFound();
            }


            return mapper.Map<DeliveriesDTO>(deliveries);

        }


        [HttpPost]

        public async Task<ActionResult> Post([FromBody] DeliveriesCreacionDTO deliveriesCreacionDTO)
        {


            var deliveries = mapper.Map<Deliveries>(deliveriesCreacionDTO);
            context.Add(deliveries);
            await context.SaveChangesAsync();
            return NoContent(); //204


        }



        [HttpPut("{id}")]

        public async Task<ActionResult> Put(Deliveries deliveries, int id)
        {

            if (deliveries.DeliveriesId != id)
            {
                return BadRequest("el delivery no existe");
            }

            var existe = await context.Deliveries.AnyAsync(x => x.DeliveriesId == id);

            if (!existe)
            {

                return NotFound();



            }

            context.Update(deliveries);
            await context.SaveChangesAsync();
            return Ok(); //200


        }


        [HttpDelete("{id}")]

        public async Task<ActionResult> Delete(int id)
        {


            var delivery = await context.Deliveries.FirstOrDefaultAsync(x => x.DeliveriesId == id);

            if (delivery == null)
            {

                return NotFound();
            }

            context.Remove(delivery);
            await context.SaveChangesAsync();
            return NoContent(); //204


        }
    }
}
