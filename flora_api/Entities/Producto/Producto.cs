using api_flora.Entities.Categorias;

namespace api_flora.Entities.Producto
{
    public class Producto
    {
        private long id;
        private String nombre;
        private int precio;
        private int cantidad;
        private String description;
        private Categoria categoria;


        public long Id
        {
            get { return this.id; }
            set { this.id = value; }
        }

        public String Nombre
        {
            get { return this.nombre; }
            set { this.nombre = value; }
        }

        public int Precio
        {
            get { return this.precio; }
            set { this.precio = value; }
        }

        public int Cantidad
        {
            get { return this.cantidad; }
            set { this.cantidad = value; }
        }

        public String Descripcion
        {
            get { return this.description; }
            set { this.description = value; }
        }
        public Categoria Categoria
        {
            get { return this.categoria; }
            set { this.categoria = value; }
        }
    }
}