using APi.Model;

public class Pelicula : BaseModel
{
    public required string Titulo { get; set; }
    public HashSet<Genero> Genero { get; set; } = [];
    public HashSet<Personaje> Personajes { get; set; } = [];


    public required int AnioLanzamiento { get; set; }
}

