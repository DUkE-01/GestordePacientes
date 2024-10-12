using GestordePacientes.Core.Application.Interfaces;
using GestordePacientes.Core.Application.ViewModels;
using GestordePacientes.Core.Domain.Entities;
using GestordePacientes.Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore; 
using System.Threading.Tasks;

namespace GestordePacientes.Infrastructure.Persistence.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationContext _context;

        public UserRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task AddAsync(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }
        public async Task<User> GetByEmailAndPasswordAsync(string email, string password)
        {
           
            return await _context.Users
                .FirstOrDefaultAsync(u => u.Email == email && u.Password == password); 
        }
        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _context.Users.ToListAsync(); 
        }

        public async Task DeleteAsync(int IdUser)
        {
            var user = await _context.Users.FindAsync(IdUser);
            if (user != null)
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
            }
        }
        public async Task DeleteAsync(User user)
        {
            if (user != null)
            {
                _context.Users.ToHashSet<User>().Remove(user);
                await _context.SaveChangesAsync();
            }
        }
        public async Task<bool> ExistsByUserNameAsync(string username)
        {
            return await _context.Users.AnyAsync(u => u.UserName == username);
        }
        public async Task<bool> ExistsByEmailAsync(string? email)
        {
            return await _context.Users.AnyAsync(u => u.Email == email);
        }
        public async Task UpdateAsync(User user)
        {
            _context.Users.Entry(user).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
