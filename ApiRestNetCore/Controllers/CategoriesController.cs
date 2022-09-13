using ApiRestNetCore.Data;
using ApiRestNetCore.DTOs;
using ApiRestNetCore.Entidades;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiRestNetCore.Controllers
{
    [ApiController]
    [Route("api/categories")]
    public class CategoriesController : Controller
    {
        private readonly ILogger<CategoriesController> logger;
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public CategoriesController(ILogger<CategoriesController> logger, ApplicationDbContext context, IMapper mapper)
        {
            this.logger = logger;
            this.context = context;
            this.mapper = mapper;
        }


        //Select * from genero
        [HttpGet]
        public async Task<ActionResult<List<Categories>>> Get()
        {

            return await context.Categories.ToListAsync();


        }

        // Búsqueda por parámetro
        [HttpGet("{id:int}")]
        public async Task<ActionResult<CategoriesDTO>> Get(int id)
        {

            var category = await context.Categories.FirstOrDefaultAsync(x => x.CategoryId == id);


            if (category == null)
            {


                return NotFound();
            }


            return mapper.Map<CategoriesDTO>(category);

        }


        [HttpPost]

        public async Task<ActionResult> Post([FromBody] CategoriesCreacionDTO categoriesCreacionDTO)
        {


            var categories = mapper.Map<Categories>(categoriesCreacionDTO);
            context.Add(categories);
            await context.SaveChangesAsync();
            return NoContent(); //204


        }



        [HttpPut("{id}")]

        public async Task<ActionResult> Put(Categories categories, int id)
        {

            if (categories.CategoryId != id)
            {
                return BadRequest("la categoria no existe");
            }

            var existe = await context.Categories.AnyAsync(x => x.CategoryId == id);

            if (!existe)
            {

                return NotFound();



            }

            context.Update(categories);
            await context.SaveChangesAsync();
            return Ok(); //200


        }


        [HttpDelete("{id}")]

        public async Task<ActionResult> Delete(int id)
        {


            var category = await context.Categories.FirstOrDefaultAsync(x => x.CategoryId == id);

            if (category == null)
            {

                return NotFound();
            }

            context.Remove(category);
            await context.SaveChangesAsync();
            return NoContent(); //204


        }
    }
}
