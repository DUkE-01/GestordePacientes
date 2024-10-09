using GestordePacientes.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace GestordePacientes.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult MenuAdmin()
        {
            return View();
        }
        public IActionResult MenuAssistant()
        {
            return View();
        }
        public IActionResult Pacientes()
        {
            return View();
        }
        public IActionResult Citas()
        {
            return View();
        }
        public IActionResult ResultadosPruebasLaboratorio()
        {
            return View();
        }
        public IActionResult Medicos()
        {
            return View();
        }
        public IActionResult Usuarios()
        {
            return View();
        }
        public IActionResult PruebasLaboratorio()
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
