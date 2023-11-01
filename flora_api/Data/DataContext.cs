using Microsoft.EntityFrameworkCore;
using api_flora.Entities.productos;
using api_flora.Entities.categorias;

namespace api_flora.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        { 
                
        }

        public DbSet<Producto>? Productos { get; set; }

        public DbSet<Categoria>? Categorias { get; set; }
    }
}
