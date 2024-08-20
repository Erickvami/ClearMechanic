using Microsoft.EntityFrameworkCore;
using ClearMechanic.Data.Models;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Actor> Actors { get; set; }
    public DbSet<Genre> Genres { get; set; }
    public DbSet<Movie> Movies { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Seed data
        modelBuilder.Entity<Genre>().HasData(
            new Genre { Id = 1, Name = "Thriller" },
            new Genre { Id = 2, Name = "Action" },
            new Genre { Id = 3, Name = "Comedy" },
            new Genre { Id = 4, Name = "Drama" },
            new Genre { Id = 5, Name = "Science Fiction" }
        );

        modelBuilder.Entity<Actor>().HasData(
            new Actor { Id = 1, Name = "Leonardo DiCaprio", ImageURI = "https://www.usmagazine.com/wp-content/uploads/2024/01/Stars-Who-Are-Continually-Snubbed-by-the-Oscars-Leonardo-DiCaprio-Margot-Robbie-and-More-4.jpg?w=800&h=1421&crop=1&quality=86&strip=all" },
            new Actor { Id = 2, Name = "Scarlett Johansson", ImageURI = "https://hips.hearstapps.com/hmg-prod/images/dl-u560867-033-6690cc8706ad7.jpg?crop=0.6666666666666666xw:1xh;center,top&resize=640:*" },
            new Actor { Id = 3, Name = "Robert Downey Jr.", ImageURI = "https://img.europapress.es/fotoweb/fotonoticia_20130716180221_1200.jpg" },
            new Actor { Id = 4, Name = "Emma Stone", ImageURI = "https://static3.mujerhoy.com/www/multimedia/202401/26/media/cortadas/emma-stone-cambios-look-pelo-kuRH-U2101349567837EqH-1248x1248@MujerHoy.jpg" },
            new Actor { Id = 5, Name = "Tom Hanks", ImageURI = "https://es.web.img2.acsta.net/pictures/16/04/26/10/00/472541.jpg" },
            new Actor { Id = 6, Name = "Keanu Reeves", ImageURI = "https://es.web.img2.acsta.net/c_310_420/pictures/17/02/06/17/01/343859.jpg" }
        );

        modelBuilder.Entity<Movie>().HasData(
            new Movie { Id = 1, Title = "Inception", Registered = DateTime.Now, IsDeleted = false, ImageURI = "https://resizing.flixster.com/-XZAfHZM39UwaGJIFWKAE8fS0ak=/v3/t/assets/p7825626_p_v8_ae.jpg" },
            new Movie { Id = 2, Title = "Avengers: Endgame", Registered = DateTime.Now, IsDeleted = false, ImageURI = "https://m.media-amazon.com/images/M/MV5BMTc5MDE2ODcwNV5BMl5BanBnXkFtZTgwMzI2NzQ2NzM@._V1_.jpg" },
            new Movie { Id = 3, Title = "The Matrix", Registered = DateTime.Now, IsDeleted = false, ImageURI = "https://c8.alamy.com/comp/PXNB40/matrix-original-movie-poster-PXNB40.jpg" },
            new Movie { Id = 4, Title = "La La Land", Registered = DateTime.Now, IsDeleted = false, ImageURI = "https://pics.filmaffinity.com/la_la_land-262021831-mmed.jpg" },
            new Movie { Id = 5, Title = "Forrest Gump", Registered = DateTime.Now, IsDeleted = false, ImageURI = "https://m.media-amazon.com/images/I/91++WV6FP4L._AC_UF894,1000_QL80_.jpg" }
        );

        modelBuilder.Entity("ActorMovie").HasData(
            new { ActorsId = 1, MoviesId = 1 }, // Leonardo DiCaprio in Inception
            new { ActorsId = 2, MoviesId = 2 }, // Scarlett Johansson in Avengers: Endgame
            new { ActorsId = 3, MoviesId = 2 }, // Robert Downey Jr. in Avengers: Endgame
            new { ActorsId = 4, MoviesId = 4 }, // Emma Stone in La La Land
            new { ActorsId = 5, MoviesId = 5 }, // Tom Hanks in Forrest Gump
            new { ActorsId = 6, MoviesId = 3 }  // Keanu Reeves in The Matrix
        );

        modelBuilder.Entity("GenreMovie").HasData(
            new { GenresId = 1, MoviesId = 1 }, // Thriller in Inception
            new { GenresId = 2, MoviesId = 2 }, // Action in Avengers: Endgame
            new { GenresId = 2, MoviesId = 3 }, // Action in The Matrix
            new { GenresId = 3, MoviesId = 4 }, // Comedy in La La Land
            new { GenresId = 4, MoviesId = 5 }  // Drama in Forrest Gump
        );
    }   
}