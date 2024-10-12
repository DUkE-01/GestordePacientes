using GestordePacientes.Core.Application.Services;
using GestordePacientes.Core.Application.ViewModels.User;
using GestordePacientes.Core.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GestordePacientes.Controllers
{
    [Authorize(Roles = "Administrador")]
    public class UsuariosController : Controller
    {
        private readonly UserService _userService;

        public UsuariosController(UserService userService)
        {
            _userService = userService;
        }

        // Método para eliminar un usuario
        [HttpPost("delete/{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            try
            {
                await _userService.DeleteUserAsync(id);
                return Ok("Usuario eliminado exitosamente.");
            }
            catch (Exception ex)
            {
                return BadRequest("Error al eliminar el usuario: " + ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] UserViewModel userViewModel)
        {
            if (userViewModel == null)
                return BadRequest("Los datos del usuario son nulos.");

            // Validación de campos
            if (string.IsNullOrWhiteSpace(userViewModel.Name) ||
            string.IsNullOrWhiteSpace(userViewModel.UserName) ||
            string.IsNullOrWhiteSpace(userViewModel.Email) ||
            string.IsNullOrWhiteSpace(userViewModel.Password) ||
            string.IsNullOrWhiteSpace(userViewModel.ConfirmePassword) ||
            string.IsNullOrWhiteSpace(userViewModel.Rol))
            {
                ViewData["mensaje"] = "Todos los campos deben ser completados.";
                return View(userViewModel);
            }

            if (userViewModel.Password != userViewModel.ConfirmePassword)
            {
                ViewData["mensaje"] = "Las contraseñas no coinciden.";
                return View(userViewModel);
            }

            if (await _userService.CheckUserExists(userViewModel.UserName))
            {
                ViewData["mensaje"] = "El nombre de usuario ya existe. Por favor elige otro.";
                return View(userViewModel);
            }

            TempData["mensaje"] = "Usuario creado exitosamente.";
            return RedirectToAction("Index");

            await _userService.AddAsync(userViewModel);
            return Ok("Usuario creado exitosamente.");
        }

        [HttpGet("check-username")]
        public async Task<IActionResult> CheckUsername(string username)
        {
            var userExists = await _userService.CheckUserExists(username);
            return Ok(userExists);
        }

        public IActionResult Index()
        {
            var users = _userService.GetAllUsersAsync();
            return View(users);
        }
    }
}
