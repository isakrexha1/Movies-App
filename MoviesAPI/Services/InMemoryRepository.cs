using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MoviesAPI.Entities;

namespace MoviesAPI.Services
{
    public class InMemoryRepository : IRepository
    {
        private readonly ILogger<InMemoryRepository> _logger;
        private List<Genre> _genres;

        public InMemoryRepository(ILogger<InMemoryRepository>? logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _genres = new List<Genre>()
            {
                new Genre () {Id = 1, Name ="Comedy"},
                new Genre () {Id = 2, Name = "Action"}
            };
        }

        public async Task<List<Genre>> GetAllGenres()
        {
            _logger.LogInformation("Executing GetAllGenres");
            await Task.Delay(3000);
            return _genres;
        }

        public Genre GetGenreById(int Id)
        {
            return _genres.FirstOrDefault(x => x.Id == Id);
        }

        public void AddGenre(Genre genre)
        {
            genre.Id = _genres.Max(x => x.Id) + 1;
            _genres.Add(genre);
        }
    }
}
