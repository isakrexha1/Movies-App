using MoviesAPI.Services;

namespace MoviesAPI.Controllers
{
    public class GenresController
    {

        private readonly IRepository repository;

        public GenresController(IRepository repository)
        {
            this.repository = repository;
        }
    }
}
