using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MoviesAPI.Entities;
using MoviesAPI.Filters;
using MoviesAPI.Services;

namespace MoviesAPI.Controllers
{
    [Route("api/genres")]
    [ApiController]

    public class GenresController : ControllerBase
    {

        private readonly IRepository repository;
        private readonly ILogger<GenresController> logger;

        public GenresController(IRepository repository, ILogger<GenresController> logger)
        {
            this.repository = repository;
            this.logger = logger;
        }
        [HttpGet]//api/genres
        [HttpGet("list")]//api/genres/list
        [HttpGet("/allgenres")]//allgenres
        //[ResponseCache(Duration = 60)]
        [ServiceFilter(typeof(MyActionFilter))]
        public async Task<ActionResult<List<Genre>>> Get()
        {
            logger.LogInformation("Getting all the genres");
            return await repository.GetAllGenres();
        }

        [HttpGet("{Id:int}", Name ="getGenre")]//api/genres/example
        public ActionResult<Genre> Get(int Id, string param2)
        {
            logger.LogDebug("get by Id method executing...");


            var genre = repository.GetGenreById(Id);


            if (genre == null)
            {
                logger.LogWarning($"Genre with id {Id} not found");
                logger.LogError("this is an error");
                //throw new ApplicationException();
                return NotFound();
            }
           
            return genre;
        }
        [HttpPost]
        public ActionResult Post([FromBody] Genre genre)
        {
            repository.AddGenre(genre);
            return new CreatedAtRouteResult("getGenre", new { Id = genre.Id }, genre);
        }
        [HttpPut]
        public ActionResult Put([FromBody] Genre genre)
        {

            return NoContent();
        }
        [HttpDelete]
        public ActionResult Delete()
        {
            return NoContent();
        }
    }
}
