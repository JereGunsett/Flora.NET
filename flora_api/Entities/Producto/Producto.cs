using api_flora.Entities.Categorias;

namespace api_flora.Entities.Producto
{
    public class Producto
    {
        private long id = 0;
        private String nombre = "";
        private double precio = 0;
        private int cantidad = 0;
        private String description = "";
        private Categoria? categoria;
        private String imagen = "";


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

        public double Precio
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
        public Categoria? Categoria
        {
            get { return this.categoria; }
            set { this.categoria = value; }
        }
        public String Imagen
        {
            get { return this.imagen; }
            set { this.imagen = value; }
        }
    }
}