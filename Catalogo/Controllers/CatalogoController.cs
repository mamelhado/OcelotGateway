using Microsoft.AspNetCore.Mvc;

namespace Catalogo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CatalogoController : ControllerBase
    {
        private readonly ILogger<CatalogoController> _logger;

        public CatalogoController(ILogger<CatalogoController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> Get()
        {
            return Ok(new string[] { "Frutas", "Legumes" });
        }
    }
}