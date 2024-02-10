using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MoviesAPI.Entities;
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
        }
        [HttpGet]//api/genres
        [HttpGet("list")]//api/genres/list
        [HttpGet("/allgenres")]//allgenres
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [ResponseCache(Duration = 60)]
        public async Task<ActionResult<List<Genre>>> Get()
        {
            logger.LogInformation("Getting all the genres");
            return await repository.GetAllGenres();
        }

        [HttpGet("{Id:int}")]//api/genres/example
        public ActionResult<Genre> Get(int Id, string param2)
        {
            logger.LogDebug("get by Id method executing...");


            var genre = repository.GetGenreById(Id);
            if (genre == null)
            {
                logger.LogWarning($"Genre with id {Id} not found");
                logger.LogError("this is an error");
                return NotFound();
            }
            //return Ok(2)
            // return 'felipe'
            return genre;
        }
        [HttpPost]
        public ActionResult Post([FromBody] Genre genre)
        {
            repository.AddGenre(genre);
            return NoContent();
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
