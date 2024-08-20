using Microsoft.AspNetCore.Mvc;
using ClearMechanic.Data.Models;
using ClearMechanic.Data.Services;

namespace ClearMechanic.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController(
        IMovieService movieService
    ) : ControllerBase
    {
        // GET: api/movies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Movie>>> Get()
        {
            return Ok(await movieService.GetAll());
        }

        // GET: api/movies/search/{query}
        [HttpGet("search/{query}")]
        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<Movie>>> Search(
            [FromQuery]string? genres,
            string? query = ""
        )
        {
            // get genres
            string[] g = [];
            if (!string.IsNullOrEmpty(genres)) g = genres.Split(',');

            return Ok(await movieService.SearchMovies(query ?? "", g));
        }

        // GET: api/movies/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Movie>> GetById(int id, [FromQuery]bool? hasActors, [FromQuery]bool? hasGenres)
        {
            var movie = await movieService.GetById(id, hasActors, hasGenres);
            if (movie == null) return NotFound();

            return Ok(movie);
        }

        // POST: api/movies
        [HttpPost]
        public async Task<ActionResult<Movie>> Post(Movie movie)
        {
            if (movie == null) return BadRequest("Movie cannot be null");

            movie = await movieService.CreateMovieAsync(movie);
            return CreatedAtAction(nameof(GetById), new { id = movie.Id }, movie);
        }

        // DELETE: api/movies/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await movieService.DeleteAsync(id, isSoft: true);
            return Ok();
        }
    }
}