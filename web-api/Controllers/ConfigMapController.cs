using Microsoft.AspNetCore.Mvc;

namespace web_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ConfigMapController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<ConfigMapController> _logger;
        private readonly IConfiguration _configuration;

        public ConfigMapController(ILogger<ConfigMapController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }

        [HttpGet(Name = "GetConfigMap")]
        public string Get()
        {
            _logger.LogDebug("Called the service");
            Console.WriteLine("Called the service");
            var myValue = _configuration["MyConfigKey"];
            return myValue?? "No value found from configuration";
        }
    }
}
