using Microsoft.AspNetCore.Mvc;

namespace Gateway.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HealthController : ControllerBase
    {
       

        private readonly ILogger<HealthController> _logger;

        public HealthController(ILogger<HealthController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> Heath()
        {
            return Ok("I'm fine");
        }
    }
}