using api_flora.entities.productos;
using Microsoft.AspNetCore.Mvc;


namespace api_flora.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductoController : ControllerBase
    {
        public List<Producto> productos = new List<Producto>();

        [HttpGet]
        public IEnumerable<Producto> Get()
        {
            return productos;
        }

        [HttpGet("{id}")]
        public ActionResult<Producto> Get(long id)
        {
            var producto = productos.Find(p => p.Id == id);
            if (producto == null)
            {
                return NotFound();
            }
            return producto;
        }

        [HttpPost]
        public ActionResult<Producto> Post(Producto producto)
        {
            productos.Add(producto);
            return CreatedAtAction(nameof(Get), new { id = producto.Id }, producto);
        }

        [HttpPut("{id}")]
        public IActionResult Put(long id, Producto producto)
        {
            if (id != producto.Id)
            {
                return BadRequest();
            }
            var index = productos.FindIndex(p => p.Id == id);
            if (index == -1)
            {
                return NotFound();
            }
            productos[index] = producto;
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var producto = productos.Find(p => p.Id == id);
            if (producto == null)
            {
                return NotFound();
            }
            productos.Remove(producto);
            return NoContent();
        }
    }
}