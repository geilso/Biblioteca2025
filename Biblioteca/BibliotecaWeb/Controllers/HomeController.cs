using System.Diagnostics;
using BibliotecaWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace BibliotecaWeb.Controllers
{
    public class HomeController : Controller
    {
        public const string SessionKeyUserName = "UserName";

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString(SessionKeyUserName)))
            {
                HttpContext.Session.SetString(SessionKeyUserName, "Sergiper");
            }
            var userName = HttpContext.Session.GetString(SessionKeyUserName);

            ViewData["nomeUsuario"] = userName;

            ViewBag.PerfilUsuario = "Estado";

            return View();
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
