using ApiRestNetCore.Data;
using ApiRestNetCore.DTOs;
using ApiRestNetCore.Entidades;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiRestNetCore.Controllers
{
    [ApiController]
    [Route("api/transaction")]
    public class TransactionReportsController : Controller
    {
        private readonly ILogger<TransactionReportsController> logger;
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public TransactionReportsController(ILogger<TransactionReportsController> logger, ApplicationDbContext context, IMapper mapper)
        {
            this.logger = logger;
            this.context = context;
            this.mapper = mapper;
        }


        //Select * from genero
        [HttpGet]
        public async Task<ActionResult<List<TransactionReports>>> Get()
        {

            return await context.TransactionReports.ToListAsync();


        }

        // Búsqueda por parámetro
        [HttpGet("{id:int}")]
        public async Task<ActionResult<TransactionReportsDTO>> Get(int id)
        {

            var transaction = await context.TransactionReports.FirstOrDefaultAsync(x => x.ReportId == id);


            if (transaction == null)
            {


                return NotFound();
            }


            return mapper.Map<TransactionReportsDTO>(transaction);

        }


        [HttpPost]

        public async Task<ActionResult> Post([FromBody] TransactionReportsCreacionDTO transactionCreacionDTO)
        {


            var transaction = mapper.Map<Customer>(transactionCreacionDTO);
            context.Add(transaction);
            await context.SaveChangesAsync();
            return NoContent(); //204


        }



        [HttpPut("{id}")]

        public async Task<ActionResult> Put(TransactionReports transaction, int id)
        {

            if (transaction.ReportId != id)
            {
                return BadRequest("la transaction no existe");
            }

            var existe = await context.TransactionReports.AnyAsync(x => x.ReportId == id);

            if (!existe)
            {

                return NotFound();



            }

            context.Update(transaction);
            await context.SaveChangesAsync();
            return Ok(); //200


        }


        [HttpDelete("{id}")]

        public async Task<ActionResult> Delete(int id)
        {


            var transaction = await context.TransactionReports.FirstOrDefaultAsync(x => x.ReportId == id);

            if (transaction == null)
            {

                return NotFound();
            }

            context.Remove(transaction);
            await context.SaveChangesAsync();
            return NoContent(); //204


        }
    }
}
