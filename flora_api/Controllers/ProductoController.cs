using api_flora.Entities.Producto;
using api_flora.Data;
using api_flora.DTO.Producto;
using api_flora.DTO;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.CodeAnalysis;
using System.Linq.Dynamic.Core;


namespace api_flora.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class ProductoController : ControllerBase
    {
        [NotNull]
        private readonly DataContext dataContext; //Contexto de Datos

        //Constructor para inyectar el contexto de datos
        public ProductoController(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        //Metodo GET para obtener todos los productos
        [HttpGet("type/{id}")]
        public async Task<ActionResult<List<DTOProducto>>> Get([FromRoute] long id, [FromQuery] DTOListRequest request)
        {

            var query = this.dataContext.Productos.AsQueryable();

            if (!string.IsNullOrEmpty(request.Query))
            {
                query = query.Where(producto => producto.Nombre.Contains(request.Query));
            }

            if (!string.IsNullOrEmpty(request.OrderBy))
            {
                query = query.OrderBy(request.OrderBy);
            }

            int page = request.Page ?? 1;
            int pageSize = request.PageSize ?? 10;

            var count = await query.CountAsync();

            var dtos = query
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .Select(producto => (object)new DTOProducto
                {
                    Id = producto.Id,
                    Nombre = producto.Nombre,
                    Precio = producto.Precio,
                    Cantidad = producto.Cantidad,
                    Descripcion = producto.Descripcion,
                    Imagen = producto.Imagen,
                    IdCategoria = (int)producto.Categoria.Id
                })
                .ToList();
            int pageCount = (count / pageSize) + 1;

            return Ok(new DTOListResponse
            {
                HasNextPage = (page + 1) <= pageCount,
                HasPrevPage = page > 1,
                List = dtos,
                NextPage = (page + 1) <= pageCount ? page + 1 : page,
                Page = page,
                PageSize = pageSize,
                PrevPage = page > 1 ? page - 1 : 1,
                TotalCount = count,
                TotalPage = pageCount
            });
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
            await this.dataContext.Productos.AddAsync(producto); //Agrega el producto al contexto de la base de datos
            await this.dataContext.SaveChangesAsync(); //Guarda los cambios en la base de datos
            
            return Ok(producto); //Retorna el producto agregado
        }

        //M�todo PUT para actualizar un producto existente por su ID
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
            //Si no se encuentra ning�n producto con el ID proporcionado, devuelve un resultado NotFound
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
            existingProduct.Imagen = producto.Imagen;
            
            //Marca el producto existente como modificado en el contexto de la base de datos
            this.dataContext.Productos.Update(existingProduct);
            //Guarda los cambios asincr�nicamente en la base de datos
            await this.dataContext.SaveChangesAsync();

            //Retorna un resultado sin contenido si la actualizacion se realizo correctamente
            return NoContent();
        }

        //M�todo DELETE para eliminar un producto por su ID
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