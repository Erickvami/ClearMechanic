using System.Linq.Expressions;
using ClearMechanic.Data.Models;
using ClearMechanic.Data.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ClearMechanic.Data.Services {
    public class MovieService(
        IRepository<Movie> movieRepository,
        IRepository<Actor> actorRepository,
        IRepository<Genre> genreRepository
    ): IMovieService
    {
        public async Task<IEnumerable<Movie>> GetAll()
        {
           return await movieRepository.GetAll();
        }

        public async Task<Movie?> GetById(int id, bool? hasActors, bool? hasGenres)
        {
           // consult will include actors or genres based on boolean params
            var includes = new Expression<Func<Movie, object>>[]
            {
                hasActors == true ? i => i.Actors : null,
                hasGenres == true ? i => i.Genres : null
            }.Where(e => e != null).ToArray();
            return await movieRepository.GetById(id, includes: includes);
        }

        public async Task<IEnumerable<Movie>> SearchMovies(string query, string[]? genres)
        {
            return await movieRepository.GetBy(m => 
                (string.IsNullOrEmpty(query) ||
                m.Title.ToLower().Contains(query.ToLower()) ||
                m.Actors.Any(a => a.Name.ToLower().Contains(query.ToLower()))
                ) &&
                (genres == null || genres.Length == 0 ||
                m.Genres.Any(g => genres.Contains(g.Name.ToLower())))
                && !m.IsDeleted
            );
        }

        public async Task<Movie> CreateMovieAsync(Movie movie)
        {
            await ValidateMovieAsync(movie);
            await movieRepository.Insert(movie);
            return movie;
        }

        public async Task ValidateMovieAsync(Movie movie)
        {
            // Get Actors and Genres ids
            var actorIds = movie.Actors?.Select(a => a.Id).ToList() ?? new List<int>();
            var genreIds = movie.Genres?.Select(g => g.Id).ToList() ?? new List<int>();

            // Validate actors
            if (actorIds.Any())
            {
                var existingActorIds = await actorRepository.GetBy(a => actorIds.Contains(a.Id));
                var invalidActorIds = actorIds.Except(existingActorIds.Select(a => a.Id)).ToList();
                if (invalidActorIds.Any())
                    throw new ArgumentException($"Actors with Ids {string.Join(", ", invalidActorIds)} do not exist.");
            }

            // Validate genres
            if (genreIds.Any())
            {
                var existingGenreIds = await genreRepository.GetBy(g => genreIds.Contains(g.Id));
                var invalidGenreIds = genreIds.Except(existingGenreIds.Select(g => g.Id)).ToList();
                if (invalidGenreIds.Any())
                    throw new ArgumentException($"Genres with Ids {string.Join(", ", invalidGenreIds)} do not exist.");
            }
        }

        public async Task DeleteAsync(int id, bool? isSoft = false)
        {
            var movie = await movieRepository.GetById(id);
            if (movie == null) throw new KeyNotFoundException("Movie not found");

            await movieRepository.DeleteAsync(id, isSoft: true);
        }

        public async Task UpdateMovieAsync(Movie updatedMovie)
        {
            await movieRepository.ExecuteTransaction(async () =>
            {
                // Obtener la película existente incluyendo actores y géneros
                var existingMovie = await GetById(updatedMovie.Id, true , true);

                if (existingMovie == null) throw new InvalidOperationException("Movie not found.");

                // Actualizar las propiedades simples
                existingMovie.Title = updatedMovie.Title;
                existingMovie.Description = updatedMovie.Description;
                existingMovie.Registered = updatedMovie.Registered;
                existingMovie.IsDeleted = updatedMovie.IsDeleted;
                existingMovie.ImageURI = updatedMovie.ImageURI;

                // Manejar la actualización de la relación con los actores
                existingMovie.Actors.Clear();  // Limpiar la lista actual
                foreach (var actor in updatedMovie.Actors)
                {
                    var existingActor = await actorRepository.GetById(actor.Id);
                    if (existingActor != null)
                    {
                        existingMovie.Actors.Add(existingActor);  // Agregar actores existentes
                    }
                }

                // Manejar la actualización de la relación con los géneros
                existingMovie.Genres.Clear();  // Limpiar la lista actual
                foreach (var genre in updatedMovie.Genres)
                {
                    var existingGenre = await genreRepository.GetById(genre.Id);
                    if (existingGenre != null)
                    {
                        existingMovie.Genres.Add(existingGenre);  // Agregar géneros existentes
                    }
                }

                // Usar el método UpdateAsync del repositorio para guardar los cambios
                await movieRepository.UpdateWithRelationshipsAsync(existingMovie);
            });
        }
    }
}