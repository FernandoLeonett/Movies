using APi.Model;

public class Actor : BaseModel
{

    public required string Nombre { get; set; }
    //[JsonConverter(typeof(DateFormatConverter), "dd-MM-yyyy")]
    public DateOnly FechaNac { get; init; }
    public HashSet<Personaje> Personajes { get; set; } = [];


}


