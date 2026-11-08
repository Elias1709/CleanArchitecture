using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitectureUserApi.Domain.Entities;

namespace CleanArchitectureUserApi.Application.Abstractions.Persistence
{
    public interface IUserRepository
    {
        Task AddAsync(User user);

        Task<User?> GetByIdAsync(Guid id);

        Task<List<User>> GetAllAsync();

        Task UpdateAsync(User user);

        Task DeleteAsync(User user);
    }
}
