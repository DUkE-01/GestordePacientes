﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GestordePacientes.Controllers
{
    [Authorize(Roles = "Asistente")]
    public class PacientestController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
