using APi.Model;

public class Genero : BaseModel
{

    public required string Nombre { get; set; }

    public HashSet<Pelicula> Peliculas { get; set; } = [];


}