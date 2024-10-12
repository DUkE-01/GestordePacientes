using GestordePacientes.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestordePacientes.Core.Application.ViewModels.User
{
    public class UserViewModel
    {
        public int IdUser { get; set; }
        public required string Name { get; set; }
        public required string LastName { get; set; }
        public Clinic? Clinic { get; set; }
        public required string UserName { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }

        public required string ConfirmePassword { get; set; }
        public string? Rol { get; set; }

    }
}
