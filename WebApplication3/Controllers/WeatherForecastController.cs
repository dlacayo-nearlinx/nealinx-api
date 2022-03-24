using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using WebApplication3.Jwt;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Authorization;

namespace WebApplication3.Controllers
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
        private readonly IConfiguration config;
        public WeatherForecastController(ILogger<WeatherForecastController> logger, IConfiguration config)
        {
            _logger = logger;
            this.config = config;
        }


        [HttpGet]
        [Authorize]
        public IEnumerable<WeatherForecast> Get()
        {
            Dictionary<string, string> requestHeaders = new Dictionary<string, string>();
  
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }


        [HttpPost("login")]
        public ActionResult<object> createJWT( [FromBody] User user)
        {
            var keySecret = this.config.GetValue<string>("Secret");
            JsonWebToken jwt = new JsonWebToken(keySecret);
            string mytoken = jwt.createJWT(user);

            return Ok(new
            {
                ok = true,
                token = mytoken
            });
        }
    }




    public class User
    {
        public string name { get; set; }
        public string password { get; set; }
        public string rol { get; set; }
    }
}
