namespace api_flora.Entities.Contacto
{
    public class Contacto
    {
        private long id;
        private string nombre;
        private string email;
        private string descripcion;
        private DateTime fecha;


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
        public string Email
        {
            get { return this.email; }
            set { this.email = value; }
        }
        public string Descripcion
        {
            get { return this.descripcion; }
            set { this.descripcion = value; }
        }
        public DateTime Fecha
        {
            get { return this.fecha; }
            set { this.fecha = value; }
        }
    }
}
