using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GestordePacientes.Controllers
{
    [Authorize(Roles = "Asistente")]
    public class PatientsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
