using APi.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;

namespace APi.Data;

public class MovieContext : DbContext
{

    public MovieContext(DbContextOptions<MovieContext> options) : base(options)
    {
        try
        {
            var dataBaseCreator = Database.GetService<IDatabaseCreator>() as RelationalDatabaseCreator;

            if (!dataBaseCreator.CanConnect()) dataBaseCreator.Create();


            if (!dataBaseCreator.HasTables()) dataBaseCreator.CreateTables();


        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }

    }
    // actualiza la propiedad  update on automaticamente
    public override int SaveChanges()
    {
        var modifiedEntries = ChangeTracker.Entries()
            .Where(e => e.State==EntityState.Modified&&e.Entity is BaseModel)
            .ToList();

        foreach (var entry in modifiedEntries)
        {
            // Establece la fecha actual en la propiedad "UpdateOn"
            entry.Property("UpdateOn").CurrentValue=DateTime.Now;
        }

        return base.SaveChanges();
    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {


        modelBuilder.Seed();
        base.OnModelCreating(modelBuilder);
    }

    public DbSet<Pelicula> Pelicula { get; set; }
    public DbSet<Actor> Actors { get; set; }

    public DbSet<Genero> Generos { get; set; }

    public DbSet<Personaje> Personaje { get; set; }

}
