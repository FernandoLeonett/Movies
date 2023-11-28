using Microsoft.EntityFrameworkCore;

public static class SeedingModuloConsulta
{
    public static void Seed(this ModelBuilder modelBuilder)
    {

        var genereos = new List<Genero>{
            new Genero { Id=Guid.NewGuid(), Nombre="Acción" },
           new Genero { Id=Guid.NewGuid(), Nombre="Drama" },
           new Genero { Id=Guid.NewGuid(), Nombre="Comedia" }


        };
        modelBuilder.Entity<Genero>().HasData(genereos);



        var actores = new List<Actor>
        {

            new Actor { Id=Guid.NewGuid(), Nombre="Tom Hanks" },
            new Actor { Id=Guid.NewGuid(), Nombre="Scarlett Johansson" },
            new Actor { Id=Guid.NewGuid(), Nombre="Robert Downey Jr." }


    };
        modelBuilder.Entity<Actor>().HasData(actores);
        var peliculas = new List<Pelicula>
        {
             new Pelicula { Id=Guid.NewGuid(), Titulo="Avengers: Endgame", AnioLanzamiento=2019 },
            new Pelicula { Id=Guid.NewGuid(), Titulo="Forrest Gump", AnioLanzamiento=1994 }
        };


        modelBuilder.Entity<Pelicula>().HasData(peliculas);

        modelBuilder.Entity<Personaje>().HasData(
            new Personaje
            {
                Id=Guid.NewGuid(),
                NombrePersonaje="Iron Man",
            },
            new Personaje { Id=Guid.NewGuid(), NombrePersonaje="Forrest Gump" },
            new Personaje
            {
                Id=Guid.NewGuid(),
                NombrePersonaje="Black Widow"
            });
    }
}
