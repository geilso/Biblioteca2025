using BibliotecaWeb.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BibliotecaWeb.Controllers
{
    public class HomeController : Controller
    {
        public const string SessionKeyUserName = "UserName";
        public const string PerfilAluno = "Aluno";

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString(SessionKeyUserName)))
            {
                HttpContext.Session.SetString(SessionKeyUserName, "Geilson");
            }
            var userName = HttpContext.Session.GetString(SessionKeyUserName);

            var viewModel = new HomeViewModel
            {
                NomeUsuario = userName ?? string.Empty,
                PerfilUsuario = PerfilAluno
            };

            return View(viewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
