using GestordePacientes.Models;
using Microsoft.AspNetCore.Authorization;
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

        // Solo Administradores pueden acceder a MenuAdmin
        [Authorize(Roles = "Administrador")]
        public IActionResult MenuAdmin()
        {
            return View();
        }

        // Solo Asistentes pueden acceder a MenuAssistant
        [Authorize(Roles = "Asistente")]
        public IActionResult MenuAssistant()
        {
            return View();
        }

        public IActionResult Login_Register()
        {
            return View("Login_Register");
        }
        public IActionResult AccessDenied()
        {
            return StatusCode(403); 
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
