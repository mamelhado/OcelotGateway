using Microsoft.AspNetCore.Mvc;

namespace Identity.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TokenController : ControllerBase
    {
        private readonly ILogger<TokenController> _logger;

        public TokenController(ILogger<TokenController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        [Route("")]
        public IActionResult GenerateToken([FromBody] AuthUser user)
        {
            return Ok(AuthTokenExtensions.GenerateToken(user));
        }
    }
}