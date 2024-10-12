using Microsoft.AspNetCore.Mvc;
using GestordePacientes.Core.Application.Services;
using System.Threading.Tasks;
using GestordePacientes.Core.Application.ViewModels.User;

namespace GestordePacientes.Controllers
{
    public class AccessController : Controller
    {
        private readonly UserService _userService;

        public AccessController(UserService userService)
        {
            _userService = userService;
        }

        // GET: /Access/Login
        [HttpGet]
        public IActionResult Login()
        {
            return View("Login_Register");
        }

        // POST: /Access/Login
        [HttpPost]
        public async Task<IActionResult> Login(UserViewModel vm)
        {
            var user = await _userService.Authenticate(vm.Email, vm.Password);

            if (user != null)
            {
                TempData["mensaje"] = "Login exitoso!";

                // Verificar el rol del usuario
                if (user.Rol == "Administrador")
                {
                    return RedirectToAction("MenuAdmin", "Home"); // Redirige al menú del administrador
                }
                else if (user.Rol == "Asistente")
                {
                    return RedirectToAction("MenuAssistant", "Home"); // Redirige al menú del asistente
                }
                else
                {
                    // En caso de que el rol no sea reconocido, podrías redirigir a una vista por defecto
                    return RedirectToAction("Login_Register", "Home");
                }
            }
            else
            {
                ViewData["mensaje"] = "Correo o contraseña incorrectos.";
                return View(vm);
            }
        }

        // GET: /Access/Register
        [HttpGet]
        public IActionResult Register()
        {
            return View("Login_Register");
        }

        // POST: /Access/Register
        [HttpPost]
        public async Task<IActionResult> Register(UserViewModel oUsuario)
        {
            if (oUsuario.Password == oUsuario.ConfirmePassword)
            {
                try
                {
                    oUsuario.ConfirmePassword = null;
                    await _userService.AddAsync(oUsuario);
                    TempData["mensaje"] = "Usuario registrado correctamente.";
                    return RedirectToAction("Login_Register");
                }
                catch (Exception ex)
                {
                    ViewData["mensaje"] = "Error al registrar usuario: " + ex.Message;
                }
            }
            else
            {
                ViewData["mensaje"] = "Las contraseñas no coinciden.";
            }

            return View(oUsuario);
        }

        public IActionResult AccessDenied()
        {
            return StatusCode(403); // Devuelve un estado 403
        }
    }
}
