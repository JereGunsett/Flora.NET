using api_flora.Entities.Categorias;

namespace api_flora.DTO.Producto
{
    public class DTOProducto
    {
        public long Id { get; set; } = 0;

        public string Nombre { get; set; } = "";

        public double Precio { get; set; } = 0;

        public int Cantidad { get; set; } = 0;

        public string Descripcion { get; set; } = "";

        public string Imagen { get; set; } = "";

        public long IdCategoria {  get; set; } = 0; 
    }
}
