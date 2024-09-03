
using ClearMechanic.Data.Models;

namespace ClearMechanic.Data.Services {
    public interface IMovieService
    {
        Task<IEnumerable<Movie>> GetAll();
        Task<Movie?> GetById(int id, bool? hasActors, bool? hasGenres);
        Task<IEnumerable<Movie>> SearchMovies(string query, string[]? genres);
        Task<Movie> CreateMovieAsync(Movie movie);
        Task ValidateMovieAsync(Movie movie);
        Task DeleteAsync(int id, bool? isSoft = false);
        Task UpdateMovieAsync(Movie updatedMovie);
    }
}