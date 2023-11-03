using Microsoft.EntityFrameworkCore;
using api_flora.Entities.Producto;
using api_flora.Entities.Categorias;
using api_flora.Entities.Noticia;
using api_flora.Entities.Contacto;
using System.Diagnostics.CodeAnalysis;

namespace api_flora.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        { 
                
        }

        [NotNull]
        public DbSet<Producto>? Productos { get; set; }

        [NotNull]
        public DbSet<Categoria>? Categorias { get; set; }

        [NotNull]
        public DbSet<Noticia>? Noticias { get; set; }

        [NotNull]
        public DbSet<Contacto>? Contactos { get; set; }
    }
}
