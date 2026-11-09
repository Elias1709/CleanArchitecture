using CleanArchitectureUserApi.Application.Abstractions.Persistence;
using CleanArchitectureUserApi.Domain.Entities;
using CleanArchitectureUserApi.Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitectureUserApi.Infrastructure.Persistence.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;
        public UserRepository(
            ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(User user)
        {
            await _context.Users.AddAsync(user);

            await _context.SaveChangesAsync();
        }
        public async Task<User?> GetByIdAsync(Guid id)
        {
            return await _context.Users
                .FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<List<User>> GetAllAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<(List<User> Users, int TotalRecords)> GetPagedAsync(int pageNumber, int pageSize)
        {
            var totalRecords = await _context.Users.CountAsync();
            var users = await _context.Users
                                            .OrderBy(x => x.Nombres)
                                            .Skip((pageNumber - 1) * pageSize)
                                            .Take(pageSize)
                                            .ToListAsync();
            return (users, totalRecords);
        }
        public async Task UpdateAsync(User user)
        {
            _context.Users.Update(user);

            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(User user)
        {
            _context.Users.Remove(user);

            await _context.SaveChangesAsync();
        }
    }
}
