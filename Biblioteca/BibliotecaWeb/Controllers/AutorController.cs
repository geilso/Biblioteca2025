using AutoMapper;
using Core.Service;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace BibliotecaWeb.Controllers
{
    public class AutorController : Controller
    {
        private readonly IAutorService autorService;
        private readonly IMapper mapper;

        public AutorController(IAutorService autorService, IMapper mapper)
        {
            this.autorService = autorService;
            this.mapper = mapper;
        }

        // GET: AutorController
        public ActionResult Index()
        {
            var listaAutores = autorService.GetAll();
            var listaAutorViewModel = mapper.Map<List<AutorViewModel>>(listaAutores);
            return View(listaAutorViewModel);
        }

        // GET: AutorController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AutorController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AutorController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AutorController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AutorController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AutorController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AutorController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
