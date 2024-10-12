using System.Threading.Tasks;
using GestordePacientes.Core.Domain.Entities;
using GestordePacientes.Core.Application.Interfaces;
using GestordePacientes.Core.Application.ViewModels.User;

namespace GestordePacientes.Core.Application.Services
{
    public class UserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<bool> CheckUserExists(string username)
        {
            return await _userRepository.ExistsByUserNameAsync(username);
        }

        public async Task AddAsync(UserViewModel vm)
        {
            
            if (await _userRepository.ExistsByEmailAsync(vm.Email))
            {
                throw new Exception("El correo electrónico ya está en uso.");
            }

            if (await _userRepository.ExistsByUserNameAsync(vm.UserName))
            {
                throw new Exception("El nombre de usuario ya está en uso.");
            }


            User newUser = new()
            {
                Name = vm.Name,
                LastName = vm.LastName,
                UserName = vm.UserName,
                Email = vm.Email,
                Password = vm.Password, 
                Rol = vm.Rol
            };

            // Agregar el nuevo usuario al repositorio
            await _userRepository.AddAsync(newUser);
        }

        public async Task Update(UserViewModel vm)
        {
            User user = new()
            {
                IdUser = vm.IdUser,
                Name = vm.Name,
                UserName = vm.UserName,
                Email = vm.Email,
                Password = vm.Password,
                Rol = vm.Rol
            };

            await _userRepository.UpdateAsync(user);
        }
        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _userRepository.GetAllAsync();
        }
        public async Task DeleteUserAsync(int IdUser)
        {
            await _userRepository.DeleteAsync(IdUser);
        }
        public async Task<User> Authenticate(string email, string password)
        {
            var user = await _userRepository.GetByEmailAndPasswordAsync(email, password);

            if (user != null && user.Password == password)
            {
                return user;
            }

            return null;
        }
    }
}
