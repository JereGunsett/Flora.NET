using Microsoft.EntityFrameworkCore;
using api_flora.Entities.Producto;
using api_flora.Entities.Categorias;
using api_flora.Entities.Noticia;
using api_flora.Entities.Contacto;

namespace api_flora.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        { 
                
        }

        public DbSet<Producto>? Productos { get; set; }

        public DbSet<Categoria>? Categorias { get; set; }

        public DbSet<Noticia>? Noticias { get; set; }

        public DbSet<Contacto>? Contactos { get; set; }
    }
}
