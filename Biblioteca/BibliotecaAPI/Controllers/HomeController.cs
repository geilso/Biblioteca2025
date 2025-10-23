using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BibliotecaAPI.Controllers
{
    [ApiController] 
    [Route("api/[controller]")] 
    public class HomeController : ControllerBase 
    {
        private readonly ILogger<HomeController> logger;

        public HomeController(ILogger<HomeController> logger)
        {
            this.logger = logger;
        }

        // GET: api/home
        [HttpGet]
        public IActionResult Index()
        {
            return Ok(new { mensagem = "API Biblioteca funcionando corretamente!" });
        }

        // GET: api/home/privacy
        [HttpGet("privacy")]
        public IActionResult Privacy()
        {
            return Ok(new { mensagem = "Política de privacidade da API Biblioteca." });
        }

        // GET: api/home/error
        [HttpGet("error")]
        public IActionResult Error()
        {
            return Problem("Ocorreu um erro interno na API Biblioteca.");
        }
    }
}
