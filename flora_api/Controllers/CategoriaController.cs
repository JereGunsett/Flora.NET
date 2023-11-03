using api_flora.Entities.Categorias;
using api_flora.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.CodeAnalysis;


namespace api_flora.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class CategoriaController : ControllerBase
    {
        [NotNull]
        private readonly DataContext dataContext; //Contexto de Datos

        public CategoriaController(DataContext dataContext) //Constructor para inyectar el contexto de datos
        {
            this.dataContext = dataContext;
        }

        //Metodo GET para obtener todas las categorias
        [HttpGet]
        public IEnumerable<Categoria> Get()
        {
            return this.dataContext.Categorias.ToList();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Categoria>> Get(long id)
        {
            var categoria = await this.dataContext.Categorias.FindAsync(id);

            if (categoria == null)
            {
                return NotFound("La categoria no existe");
            }

            return categoria;
        }


        //Metodo POST para agregar una nueva categoria
        [HttpPost]
        public async Task<ActionResult<Categoria>> Post([FromBody]Categoria categoria)
        {
            await this.dataContext.Categorias.AddAsync(categoria);
            await this.dataContext.SaveChangesAsync();
            
            return Ok(categoria);
        }

        //Metodo PUT que actualiza los parametros de una categoria a traves de su id
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(long id, Categoria categoria)
        {
            if (id != categoria.Id)
            {
                return BadRequest();
            }

            var existingCategoria = await this.dataContext.Categorias.FindAsync(id);

            if (existingCategoria == null)
            {
                return NotFound();
            }

            existingCategoria.Nombre = categoria.Nombre;
            existingCategoria.Descripcion = categoria.Descripcion;
            existingCategoria.Imagen = categoria.Imagen;

            this.dataContext.Categorias.Update(existingCategoria);

            await this.dataContext.SaveChangesAsync();

            return NoContent();
        }

        //Metodo DELETE que elimina una categoria a travez de su id
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var existingCategoria = await this.dataContext.Categorias.FindAsync(id);
            if (existingCategoria == null)
            {
                return NotFound();
            }
            this.dataContext.Categorias.Remove(existingCategoria);

            await this.dataContext.SaveChangesAsync();

            return NoContent();
        }
    }
}