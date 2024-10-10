using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Application.ViewModels;

namespace GestordePacientes.Controllers
{
    public class AccountController : Controller
    {
        // GET: /Account/Login
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        // POST: /Account/Login
        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Intentamos encontrar el usuario con el nombre de usuario proporcionado
                var user = await _userManager.FindByNameAsync(model.UserName);

                if (user != null)
                {
                    // Verificamos si la contraseña es correcta
                    var result = await _signInManager.PasswordSignInAsync(user, model.Password, false, lockoutOnFailure: false);
                    if (result.Succeeded)
                {
                    return RedirectToAction("MenuAdmin", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Usuario o contraseña incorrectos");
                }
            }
            return View(model);
        }

        // GET: /Account/Register
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        // POST: /Account/Register
        [HttpPost]
        public IActionResult Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Aquí iría tu lógica de registro
                return RedirectToAction("Login");
            }
            return View(model);
        }
        public IActionResult AccessDenied()
        {
            return View();
        }
    }

}

