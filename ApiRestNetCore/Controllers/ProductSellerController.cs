using ApiRestNetCore.Data;
using ApiRestNetCore.DTOs;
using ApiRestNetCore.Entidades;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiRestNetCore.Controllers
{
    [ApiController]
    [Route("api/productSeller")]
    public class ProductSellerController : Controller
    {
        private readonly ILogger<ProductSellerController> logger;
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public ProductSellerController(ILogger<ProductSellerController> logger, ApplicationDbContext context, IMapper mapper)
        {
            this.logger = logger;
            this.context = context;
            this.mapper = mapper;
        }


        //Select * from genero
        [HttpGet]
        public async Task<ActionResult<List<ProductSeller>>> Get()
        {

            return await context.ProductSeller.ToListAsync();


        }

        // Búsqueda por parámetro
        [HttpGet("{id:int}")]
        public async Task<ActionResult<ProductSellerDTO>> Get(int id)
        {

            var product = await context.ProductSeller.FirstOrDefaultAsync(x => x.ProductId == id);


            if (product == null)
            {


                return NotFound();
            }


            return mapper.Map<ProductSellerDTO>(product);

        }


        [HttpPost]

        public async Task<ActionResult> Post([FromBody] ProductSellerCreacionDTO productSellerCreacionDTO)
        {


            var product = mapper.Map<Categories>(productSellerCreacionDTO);
            context.Add(product);
            await context.SaveChangesAsync();
            return NoContent(); //204


        }



        [HttpPut("{id}")]

        public async Task<ActionResult> Put(ProductSeller product, int id)
        {

            if (product.ProductId != id)
            {
                return BadRequest("la categoria no existe");
            }

            var existe = await context.ProductSeller.AnyAsync(x => x.ProductId == id);

            if (!existe)
            {

                return NotFound();



            }

            context.Update(product);
            await context.SaveChangesAsync();
            return Ok(); //200


        }


        [HttpDelete("{id}")]

        public async Task<ActionResult> Delete(int id)
        {


            var product = await context.ProductSeller.FirstOrDefaultAsync(x => x.ProductId == id);

            if (product == null)
            {

                return NotFound();
            }

            context.Remove(product);
            await context.SaveChangesAsync();
            return NoContent(); //204


        }
    }
}
