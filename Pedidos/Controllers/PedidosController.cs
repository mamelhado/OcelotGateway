using Microsoft.AspNetCore.Mvc;

namespace Produtos.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PedidosController : ControllerBase
    {

        private readonly ILogger<PedidosController> _logger;

        public PedidosController(ILogger<PedidosController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> Get()
        {
            return Ok(new string[] { "Banana", "Tomate" });
        }
    }
}