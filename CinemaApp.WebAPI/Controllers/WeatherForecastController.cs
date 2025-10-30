using CinemaApp.Data;
using CinemaApp.Services.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CinemaApp.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly CinemaAppDBContext _dbContext;// test
        private readonly IMovieService  _movieService;
        public WeatherForecastController(ILogger<WeatherForecastController> logger,CinemaAppDBContext dBContext,IMovieService movieService)
        {
            _logger = logger;
            _dbContext = dBContext;
            _movieService = movieService;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
