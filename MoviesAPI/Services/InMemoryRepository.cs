using MoviesAPI.Entities;

namespace MoviesAPI.Services
{
    public class InMemoryRepository : IRepository
    {

        private List<Genre> _genres;
        private readonly ILogger<InMemoryRepository> logger;

        public InMemoryRepository(ILogger<InMemoryRepository> logger)
        {
            _genres = new List<Genre>()
            {
                new Genre () {Id = 1, Name ="Comedy"},
                new Genre () {Id = 2, Name = "Action"}
            };
        }

        public async Task<List<Genre>> GetAllGenres()
        {
            logger.LogInformation("Executing GetAllGenres");
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
