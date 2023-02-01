using Microsoft.AspNetCore.Mvc;
using PortafolioRayo.Models;
using PortafolioRayo.Servicios;
using System.Diagnostics;

namespace PortafolioRayo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IRepositorioProyectos repositorioProyectos;
        private readonly IServicioEmail servicioEmail;

        public HomeController(ILogger<HomeController> logger,
            IRepositorioProyectos repositorioProyectos,
            IServicioEmail servicioEmail)
        {
            _logger = logger;
            this.repositorioProyectos = repositorioProyectos;
            this.servicioEmail = servicioEmail;
        }

        public IActionResult Index()
        {
            var proyectos = repositorioProyectos.ObtenerProyecto().Take(1).ToList();

            var modelo = new HomeIndexViewModel()
            {
                Proyecto = proyectos
            };
            return View(modelo);
        }

        public IActionResult PopupView()
        {
            return View();
        }

        public IActionResult ViewPopup()
        {
            return View();
        }
        public IActionResult Contacto()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Contacto(ContactoViewModel contactoViewModel)
        {
            await servicioEmail.Enviar(contactoViewModel);
            return RedirectToAction("Gracias");
        }

        public IActionResult Gracias()
        {
            return View();
        }

        public IActionResult Proyectos()
        {
            var proyectos = repositorioProyectos.ObtenerProyecto();
            return View(proyectos);
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