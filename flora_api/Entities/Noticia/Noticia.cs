
namespace api_flora.Entities.Noticia
{
    public class Noticia
    {
        private long id;
        private string titulo;
        private string cuerpo;
        private List<ImagenNoticia> imagenes;
        private List<HipervinculoNoticia> hipervinculos;

        public long Id
        {
            get { return this.id; }
            set { this.id = value; }
        }
        public string Titulo
        {
            get { return this.titulo; }
            set { this.titulo = value; }
        }
        public string Cuerpo
        {
            get { return this.cuerpo; }
            set { this.cuerpo = value; }
        }
        public List<ImagenNoticia> Imagenes
        {
            get { return this.imagenes; }
            set { this.imagenes = value; }
        }
        public List<HipervinculoNoticia> Hipervinculos
        {
            get { return this.hipervinculos; }
            set { this.hipervinculos = value; }
        }
    }
}