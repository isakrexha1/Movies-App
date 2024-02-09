using Microsoft.Extensions.Logging;
using MoviesAPI.Controllers;
using MoviesAPI.Services;

namespace MoviesAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var weatherForecastController = new WeatherForecastController();
            weatherForecastController.Get();

            //var genresControlle = new GenresController(new InMemoryRepository(new Logger()));


            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
