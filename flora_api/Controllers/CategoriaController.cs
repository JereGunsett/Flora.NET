using api_flora.entities.categorias;
using Microsoft.AspNetCore.Mvc;


namespace api_flora.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoriaController : ControllerBase
    {
        private static List<Categoria> categorias = new List<Categoria>();

        [HttpGet]
        public IEnumerable<Categoria> Get()
        {
            return categorias;
        }

        [HttpPost]
        public ActionResult Post(Categoria categoria)
        {
            categorias.Add(categoria);
            return Ok();
        }

        [HttpPut("{id}")]
        public ActionResult Put(long id, Categoria categoria)
        {
            var index = categorias.FindIndex(c => c.Id == id);
            if (index < 0)
            {
                return NotFound();
            }
            categorias[index] = categoria;
            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(long id)
        {
            var index = categorias.FindIndex(c => c.Id == id);
            if (index < 0)
            {
                return NotFound();
            }
            categorias.RemoveAt(index);
            return Ok();
        }
    }
}