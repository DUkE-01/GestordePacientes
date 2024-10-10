using GestordePacientes.Core.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestordePacientes.Infrastructure.Persistence.Contexts;
using GestordePacientes.Core.Domain.Entities;


namespace GestordePacientes.Core.Application.Services
{
    public class UserService
    {
        private readonly UserService _userRepository;

        public UserService(ApplicationContext dbContext)
        {
            _userRepository = new(dbContext);
        }

        public async Task Update(UserViewModel vm)
        {
            User user = new();
            user.Id = vm.Id;
            user.Name = vm.Name;
            user.UserName = vm.UserName;
            user.Email = vm.Email;
            user.Password = vm.Password;

            await _userRepository.UpdateAsync(user);
        }

    }
}
