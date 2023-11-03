namespace api_flora.Entities.Categorias
{
    public class Categoria
    {
        private long id = 0;
        private string nombre = "";
        private string descripcion = "";
        private string imagen = "";

        public long Id
        {
            get { return this.id; }
            set { this.id = value; }
        }
        public string Nombre
        {
            get { return this.nombre; }
            set { this.nombre = value; }
        }
        public string Descripcion
        {
            get { return this.descripcion; }
            set { this.descripcion = value; }
        }
        public string Imagen
        {
            get { return this.imagen; }
            set { this.imagen = value; }
        }
    }
}