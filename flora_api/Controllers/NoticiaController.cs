using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using api_flora.Entities.Noticia;
using api_flora.Data;
using System.Diagnostics.CodeAnalysis;


namespace api_flora.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class NoticiaController : ControllerBase
    {
        [NotNull]
        private readonly DataContext dataContext;

        public NoticiaController(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        [HttpGet]
        public async Task<ActionResult<List<Noticia>>> GetNoticias()
        {
            return Ok(await this.dataContext.Noticias.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Noticia>> Get(long id)
        {
            var noticia = await this.dataContext.Noticias.FindAsync(id);

            if (noticia == null)
            {
                return NotFound("La noticia no existe");
            }

            return Ok(noticia);
        }

        [HttpPost]
        public async Task<ActionResult<Noticia>> CrearNoticia([FromBody] Noticia noticia)
        {
            try
            {
                await this.dataContext.Noticias.AddAsync(noticia);
                await this.dataContext.SaveChangesAsync();

                return CreatedAtAction(nameof(Get), new { id = noticia.Id }, noticia);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error al crear la noticia: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(long id, Noticia noticia)
        {
            if (id != noticia.Id)
            {
                return BadRequest();
            }

            var existingNoticia = await this.dataContext.Noticias.FindAsync(id);

            if (existingNoticia == null)
            {
                return NotFound();
            }

            existingNoticia.Titulo = noticia.Titulo;
            existingNoticia.Cuerpo = noticia.Cuerpo;
            existingNoticia.Hipervinculos = noticia.Hipervinculos;
            existingNoticia.Imagenes = noticia.Imagenes;

            this.dataContext.Noticias.Update(existingNoticia);

            await this.dataContext.SaveChangesAsync();

            return Ok(noticia);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var existingNoticia = await this.dataContext.Noticias.FindAsync(id);
            if (existingNoticia == null)
            {
                return NotFound();
            }
            this.dataContext.Noticias.Remove(existingNoticia);

            await this.dataContext.SaveChangesAsync();

            return NoContent();
        }
    }
}