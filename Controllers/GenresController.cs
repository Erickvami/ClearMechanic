using Microsoft.AspNetCore.Mvc;
using ClearMechanic.Data.Models;
using ClearMechanic.Data.Services;

namespace ClearMechanic.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenresController(
        IGenreService movieService
    ) : ControllerBase
    {
        // GET: api/genres
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Movie>>> Get()
        {
            return Ok(await movieService.GetAll());
        }

    }
}