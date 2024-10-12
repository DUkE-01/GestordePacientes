using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestordePacientes.Core.Domain.Entities
{
    public class User
    {
        public int IdUser { get; set; }
        public string? Name { get; set; }
        public string? UserName { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }

        public string? ConfirmePassword { get; set; }
        public string? Rol { get; set; }
        public Clinic? Clinic { get; set; }
        public string? LastName { get; set; }
    }

}
