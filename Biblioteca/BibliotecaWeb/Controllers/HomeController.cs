// Licenciado para a .NET Foundation sob um ou mais contratos.
// A .NET Foundation licencia este arquivo para voc� sob a licen�a MIT.
using BibliotecaWeb.Models;
using Core.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BibliotecaWeb.Controllers
{
    //[Authorize]
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
