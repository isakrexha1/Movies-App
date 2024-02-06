using MoviesAPI.Entities;

namespace MoviesAPI.Services
{
    public interface IRepository
    {
        List<Genre> GetAllGenres();
    }
}
