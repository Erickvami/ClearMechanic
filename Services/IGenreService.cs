
using ClearMechanic.Data.Models;

namespace ClearMechanic.Data.Services {
    public interface IGenreService
    {
        Task<IEnumerable<Genre>> GetAll();
    }
}