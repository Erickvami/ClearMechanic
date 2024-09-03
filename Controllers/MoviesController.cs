using Microsoft.AspNetCore.Mvc;
using ClearMechanic.Data.Models;
using ClearMechanic.Data.Services;
using Microsoft.EntityFrameworkCore;

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
        // PUT: api/movies
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] Movie updatedMovie)
        {
            if (id != updatedMovie.Id)
            {
                return BadRequest("The ID in the URL does not match the ID in the movie object.");
            }

            // Check if the movie exists in the database
            var existingMovie = await movieService.GetById(id, false, false);
            if (existingMovie == null)
            {
                return NotFound();
            }

            // Update the movie details
            try
            {
                await movieService.UpdateMovieAsync(updatedMovie);
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return NoContent();
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