using ApiRestNetCore.Data;
using ApiRestNetCore.DTOs;
using ApiRestNetCore.Entidades;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiRestNetCore.Controllers
{
    [ApiController]
    [Route("api/payment")]
    public class PaymentController : Controller
    {
        private readonly ILogger<PaymentController> logger;
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public PaymentController(ILogger<PaymentController> logger, ApplicationDbContext context, IMapper mapper)
        {
            this.logger = logger;
            this.context = context;
            this.mapper = mapper;
        }


        //Select * from genero
        [HttpGet]
        public async Task<ActionResult<List<Payment>>> Get()
        {

            return await context.Payment.ToListAsync();


        }

        // Búsqueda por parámetro
        [HttpGet("{id:int}")]
        public async Task<ActionResult<PaymentDTO>> Get(int id)
        {

            var payment = await context.Payment.FirstOrDefaultAsync(x => x.PaymentId == id);


            if (payment == null)
            {


                return NotFound();
            }


            return mapper.Map<PaymentDTO>(payment);

        }


        [HttpPost]

        public async Task<ActionResult> Post([FromBody] PaymentCreacionDTO paymentCreacionDTO)
        {


            var payment = mapper.Map<Customer>(paymentCreacionDTO);
            context.Add(payment);
            await context.SaveChangesAsync();
            return NoContent(); //204


        }



        [HttpPut("{id}")]

        public async Task<ActionResult> Put(Payment payment, int id)
        {

            if (payment.PaymentId != id)
            {
                return BadRequest("El payment no existe");
            }

            var existe = await context.Payment.AnyAsync(x => x.PaymentId == id);

            if (!existe)
            {

                return NotFound();



            }

            context.Update(payment);
            await context.SaveChangesAsync();
            return Ok(); //200


        }


        [HttpDelete("{id}")]

        public async Task<ActionResult> Delete(int id)
        {


            var payment = await context.Payment.FirstOrDefaultAsync(x => x.PaymentId == id);

            if (payment == null)
            {

                return NotFound();
            }

            context.Remove(payment);
            await context.SaveChangesAsync();
            return NoContent(); //204


        }
    }
}
