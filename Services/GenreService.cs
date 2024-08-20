using System.Linq.Expressions;
using ClearMechanic.Data.Models;
using ClearMechanic.Data.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ClearMechanic.Data.Services {
    public class GenreService(
        IRepository<Genre> genreRepository
    ): IGenreService
    {
        public async Task<IEnumerable<Genre>> GetAll()
        {
           return await genreRepository.GetAll();
        }

    }
}