namespace api_flora.Entities.noticias;

public class Noticia
{
	private long id;
	private string titulo;
	private string cuerpo;
	private List<string> imagenes;
	private List<string> hipervinculos;

	public long Id 
	{ 
		get { return id; }
		set { id = value; }
	}
	public string Titulo
	{
		get { return titulo; }
		set { titulo = value; }
	}
	public string Cuerpo 
	{
		get { return cuerpo; }
		set { cuerpo = value; }
	}
	public List<string> Imagenes
	{
		get { return imagenes; }
		set { imagenes = value; }
	}
	public List<string> Hipervinculos
	{
		get { return hipervinculos; }
		set { hipervinculos = value; }
	}
}
