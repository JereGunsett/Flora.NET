using api_flora.Entities.productos;
using api_flora.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;




namespace api_flora.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class ProductoController : ControllerBase
    {
        private readonly DataContext dataContext; //Contexto de Datos

        //Constructor para inyectar el contexto de datos
        public ProductoController(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        //Metodo GET para obtener todos los productos
        [HttpGet]
        public IEnumerable<Producto> Get()
        {
            return this.dataContext.Productos.ToList(); // Retorna la lista de productos desde el contexto de datos
        }

        //Metodo GET para obtener un producto por su ID
        [HttpGet("{id}")]
        public async Task<ActionResult<Producto>> Get(long id)
        {
            var producto = await this.dataContext.Productos.FindAsync(id); //Busca el producto por su ID en el contexto de datos
            if (producto == null)
            {
                return NotFound("El producto no existe"); //Retorna un resultado NotFound con una leyenda si el producto no se encuentra
            }
            return producto; //Retorna el producto si se encuentra
        }

        //Metodo POST para agregar un nuevo producto
        [HttpPost]
        public async Task<ActionResult<Producto>> Post([FromBody] Producto producto)
        {
            if (this.dataContext != null && this.dataContext.Productos != null) //Verifica si el contexto y la colección de productos no son nulos
            {
                await this.dataContext.Productos.AddAsync(producto); //Agrega el producto al contexto de la base de datos
                await this.dataContext.SaveChangesAsync(); //Guarda los cambios en la base de datos
            }

            return Ok(producto); //Retorna el producto agregado
        }

        //Método PUT para actualizar un producto existente por su ID
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(long id, Producto producto)
        {
            //Verifica si el ID del producto coincide con el ID proporcionado
            if (id != producto.Id)
            {
                //Si los ID no coinciden, devuelve un reslutado BadRequest
                return BadRequest();
            }

            //Busca dde manera asicronica un producto existente por su ID en el contexto de la base de datos
            var existingProduct = await this.dataContext.Productos.FindAsync(id);
            //Si no se encuentra ningún producto con el ID proporcionado, devuelve un resultado NotFound
            if (existingProduct == null)
            {
                return NotFound();
            }

            //Actualiza las propiedades del producto existente con las propiedades del producto recibido
            existingProduct.Nombre = producto.Nombre;
            existingProduct.Precio = producto.Precio;
            existingProduct.Cantidad = producto.Cantidad;
            existingProduct.Descripcion = producto.Descripcion;
            existingProduct.Categoria = producto.Categoria;
            
            //Marca el producto existente como modificado en el contexto de la base de datos
            this.dataContext.Productos.Update(existingProduct);
            //Guarda los cambios asincrónicamente en la base de datos
            await this.dataContext.SaveChangesAsync();

            //Retorna un resultado sin contenido si la actualizacion se realizo correctamente
            return NoContent();
        }

        //Método DELETE para eliminar un producto por su ID
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            //Busca de manera asincronica un producto existente por su ID en el contexto de la base de datos
            var existingProduct = await this.dataContext.Productos.FindAsync(id);
            //Si no se encuentra ningun producto con el ID proporcionado, devuelve un resultado NotFound
            if (existingProduct == null)
            {
                return NotFound();
            }

            //Elimina el producto existente del contexto de la base de datos
            this.dataContext.Productos.Remove(existingProduct);
            //Guarda los cambios asincronicamente en la base de datos
            await this.dataContext.SaveChangesAsync();

            //Retorna un reslutado sin contenido si la eliminacion se realizo correctamente
            return NoContent();
        }
    }
}