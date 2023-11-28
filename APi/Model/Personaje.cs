

using APi.Model;

public class Personaje : BaseModel
{
    public required string NombrePersonaje { get; set; }
    public string Descripcion { get; set; } = string.Empty;
    public HashSet<Pelicula> Peliculas { get; set; } = [];
    public HashSet<Actor> Actores { get; set; } = [];



}