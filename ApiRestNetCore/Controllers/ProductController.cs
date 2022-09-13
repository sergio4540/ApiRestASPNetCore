using ApiRestNetCore.Data;
using ApiRestNetCore.DTOs;
using ApiRestNetCore.Entidades;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiRestNetCore.Controllers
{
    [ApiController]
    [Route("api/product")]
    public class ProductController : Controller
    {
        private readonly ILogger<ProductController> logger;
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public ProductController(ILogger<ProductController> logger, ApplicationDbContext context, IMapper mapper)
        {
            this.logger = logger;
            this.context = context;
            this.mapper = mapper;
        }


        //Select * from genero
        [HttpGet]
        public async Task<ActionResult<List<Product>>> Get()
        {

            return await context.Product.ToListAsync();


        }

        // Búsqueda por parámetro
        [HttpGet("{id:int}")]
        public async Task<ActionResult<ProductDTO>> Get(int id)
        {

            var product = await context.Product.FirstOrDefaultAsync(x => x.ProductId == id);


            if (product == null)
            {


                return NotFound();
            }


            return mapper.Map<ProductDTO>(product);

        }


        [HttpPost]

        public async Task<ActionResult> Post([FromBody] ProductCreacionDTO productCreacionDTO)
        {


            var product = mapper.Map<Product>(productCreacionDTO);
            context.Add(product);
            await context.SaveChangesAsync();
            return NoContent(); //204


        }



        [HttpPut("{id}")]

        public async Task<ActionResult> Put(Product product, int id)
        {

            if (product.ProductId != id)
            {
                return BadRequest("El producto no existe");
            }

            var existe = await context.Product.AnyAsync(x => x.ProductId == id);

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


            var product = await context.Product.FirstOrDefaultAsync(x => x.ProductId == id);

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
