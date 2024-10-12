using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GestordePacientes.Controllers
{
    public class ResultadosLabController : Controller
    {
        [Authorize(Roles = "Asistente")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
