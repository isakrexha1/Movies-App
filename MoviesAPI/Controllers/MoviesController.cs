﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoviesAPI.DTOs;
using MoviesAPI.Entities;
using MoviesAPI.Helpers;


namespace MoviesAPI.Controllers
{
    [Route("api/movies")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;
        private readonly IFileStorageService fileStorageService;
        private string container = "movies";

        public MoviesController(ApplicationDbContext context, IMapper mapper,
            IFileStorageService fileStorageService)
        {
            this.context = context;
            this.mapper = mapper;
            this.fileStorageService = fileStorageService;
        }
        [HttpGet]
        public async Task<ActionResult<LandingPageDTO>> Get()
        {
            var top = 6;
            var today = DateTime.Today;

            var upcomingReleases = await context.Movies
                .Where(x => x.ReleaseDate > today)
                .OrderBy(x => x.ReleaseDate)
                .Take(top)
                .ToListAsync();

            var inTheaters = await context.Movies
                .Where(x => x.InTheaters)
                .OrderBy(x => x.ReleaseDate)
                .Take(top)
                .ToListAsync();

            var landingPageDTO = new LandingPageDTO();
            landingPageDTO.UpcomingReleases = mapper.Map<List<MovieDTO>>(upcomingReleases);
            landingPageDTO.InTheaters = mapper.Map<List<MovieDTO>>(inTheaters);
            return landingPageDTO;
        }


        [HttpGet("{id:int}")]
        public async Task<ActionResult<MovieDTO>>Get(int id)
        {
            var movie = await context.Movies
                .Include(x => x.MoviesGenres).ThenInclude(x => x.Genre)
                .Include(x => x.MovieTheatersMovies).ThenInclude(x => x.MovieTheater)
                .Include(x => x.MoviesActors).ThenInclude(x => x.Actor)
                .FirstOrDefaultAsync(x => x.Id == id);

            if(movie == null)
            {
                return NotFound();
            }
            var dto = mapper.Map<MovieDTO>(movie);
            dto.Actors=dto.Actors.OrderBy(x => x.Order).ToList();
            return dto;
        }

        [HttpGet("PostGet")]
        public async Task<ActionResult<MoviePostGetDTO>> PostGet()
        {
            var movieTheaters = await context.MovieTheaters.ToListAsync();
            var genres = await context.Genres.ToListAsync();

            var movieTheatersDTO = mapper.Map<List<MovieTheaterDTO>>(movieTheaters);
            var genresDTO = mapper.Map<List<GenreDTO>>(genres);

            return new MoviePostGetDTO() { Genres = genresDTO, MovieTheaters = movieTheatersDTO };
        }


        [HttpPost]
        public async Task<ActionResult<int>> Post([FromForm] MovieCreationDTO movieCreationDTO)
        {
            var movie = mapper.Map<Movie>(movieCreationDTO);

            if (movieCreationDTO.Poster != null)
            {
                movie.Poster = await fileStorageService.SaveFile(container, movieCreationDTO.Poster);
            }

            AnnotateActorsOrder(movie);
            context.Add(movie);
            await context.SaveChangesAsync();
            return movie.Id;
        }

        private void AnnotateActorsOrder(Movie movie)
        {
            if (movie.MoviesActors !=null)
            {
                for(int i=0; i< movie.MoviesActors.Count; i++)
                {
                    movie.MoviesActors[i].Order = i;
                }
            }
        }
    }
}