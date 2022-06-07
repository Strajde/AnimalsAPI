using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AnimalsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimalsController : ControllerBase
    {
        
        private readonly DataContext context;

        public AnimalsController(DataContext context)
        {
            this.context = context;
        }

        //Get

        [HttpGet]
        public async Task<ActionResult<List<Animals>>> Get()
        {
            return Ok(await context.Animals.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Animals>> Get(int id)
        {
            var animal =await context.Animals.FindAsync(id);
            if (animal == null)
                return BadRequest("Animal not found.");

            return Ok(animal);
        }

        //Post

        [HttpPost]
        public async Task<ActionResult<List<Animals>>> AddAnimal(Animals animal)
        {
            context.Animals.Add(animal);
            await context.SaveChangesAsync();

            return Ok(await context.Animals.ToListAsync());
        }

        //Put

        [HttpPut]
        public async Task<ActionResult<List<Animals>>> UpdateAnimal(Animals request)
        {
            var dbAnimal = await context.Animals.FindAsync(request.Id);
            if (dbAnimal == null)
                return BadRequest("Animal not found.");

            dbAnimal.Name = request.Name;
            dbAnimal.FirstName = request.FirstName;
            dbAnimal.LastName = request.LastName;
            dbAnimal.Place = request.Place;

            await context.SaveChangesAsync();

            return Ok(await context.Animals.ToListAsync());
        }

        //Delete

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Animals>>> Delete(int id)
        {
            var dbAnimal = await context.Animals.FindAsync(id);
            if (dbAnimal == null)
                return BadRequest("Animal not found.");

            context.Animals.Remove(dbAnimal);
            await context.SaveChangesAsync();

            return Ok(await context.Animals.ToListAsync());
        }

    }
}
