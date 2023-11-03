using api_flora.Entities.Contacto;
using api_flora.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.CodeAnalysis;

namespace api_flora.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class ContactoController : ControllerBase
    {
        [NotNull]
        private readonly DataContext dataContext;

        public ContactoController(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        [HttpPost]
        public async Task<ActionResult<Contacto>> PostContacto([FromBody] Contacto contacto)
        {
            contacto.Fecha = DateTime.Now; // Establece la fecha actual
            await this.dataContext.Contactos.AddAsync(contacto);
            await this.dataContext.SaveChangesAsync();
            
            return Ok(contacto);
        }
    }
}
