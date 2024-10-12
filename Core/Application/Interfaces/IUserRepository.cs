using GestordePacientes.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestordePacientes.Core.Application.Interfaces
{
    public interface IUserRepository 
    { 
    Task<User> GetByEmailAndPasswordAsync(string email, string password);
    Task UpdateAsync(User user);
    Task AddAsync(User user);
    Task<bool> ExistsByUserNameAsync(string username);
    Task DeleteAsync(User IdUser);
    Task<IEnumerable<User>> GetAllAsync();
        Task DeleteAsync(int idUser);
        Task<bool> ExistsByEmailAsync(string? email);
    }
}