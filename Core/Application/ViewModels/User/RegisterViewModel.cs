using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestordePacientes.Core.Domain.Entities;

namespace GestordePacientes.Core.Application.ViewModels.User
{
    public class RegisterViewModel
    {
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }

        [Required]
        [EmailAddress]
        public string? Correo { get; set; }

        [Required]
        [MinLength(6, ErrorMessage = "La contraseña debe tener al menos 6 caracteres.")]
        public string? Password { get; set; }

        [Required]
        [Compare("Password", ErrorMessage = "Las contraseñas no coinciden.")]
        public string? ConfirmPassword { get; set; }

        public string? NombreDeUsuario { get; set; }
        public ICollection<UserViewModel> Users { get; set; }

        public string Rol { get; set; }
    }

}

