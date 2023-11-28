using APi.Data;
using APi.DTO;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActorController : ControllerBase
    {


        private readonly MovieContext movieContext;
        private readonly IMapper mapper;

        public ActorController(MovieContext movieContext, IMapper mapper)
        {
            this.movieContext=movieContext??throw new ArgumentNullException(nameof(movieContext));
            this.mapper=mapper??throw new ArgumentNullException(nameof(mapper));
        }

        // GET: api/<ActorController>
        [HttpGet]
        public IEnumerable<Actor> Get()
        {
            return movieContext.Actors;
        }

        // GET api/<ActorController>/5
        [HttpGet("{id}")]

        public async Task<ActionResult<Actor>> Get(int id)
        {
            var actor = await movieContext.Actors.FindAsync(id);

            if (actor!=null)
            {
                return Ok(actor);
            }

            return NotFound($"No se encontró un actor con ID {id}");
        }


        // POST api/<ActorController>

        [HttpPost]
        public async Task<ActionResult<Actor>> Post([FromBody] ActorDto NuevoActor)
        {
            var nuevoActor = mapper.Map<Actor>(NuevoActor);

            await movieContext.Actors.AddAsync(nuevoActor);
            await movieContext.SaveChangesAsync();


            return CreatedAtAction(nameof(Post), new { id = nuevoActor.Id }, nuevoActor);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Actor>> Put(int id, [FromBody] ActorDto updateActor)
        {
            var existingActor = await movieContext.Actors.FindAsync(id);

            if (existingActor==null)
            {
                return NotFound($"No se encontró un actor con ID {id}");
            }

            // Mapeo de las propiedades del DTO al modelo existente
            mapper.Map(updateActor, existingActor);

            try
            {
                // Guarda los cambios en el contexto
                await movieContext.SaveChangesAsync();

                // Devuelve el actor actualizado en caso de éxito
                return Ok(existingActor);
            }
            catch (DbUpdateConcurrencyException)
            {
                // Manejo de errores de concurrencia si es necesario
                // Puedes agregar lógica aquí si la actualización no fue exitosa debido a conflictos de concurrencia
                return StatusCode(500, "La actualización del actor ha fallado debido a problemas de concurrencia.");
            }
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var existingActor = await movieContext.Actors.FindAsync(id);

            if (existingActor==null)
            {
                return NotFound($"No se encontró un actor con ID {id}");
            }

            movieContext.Actors.Remove(existingActor);

            try
            {
                await movieContext.SaveChangesAsync();
                return NoContent();
            }
            catch (Exception ex)
            {

                return StatusCode(500, $"Ocurrió un error al eliminar el actor: {ex.Message}");
            }
        }

    }
}
