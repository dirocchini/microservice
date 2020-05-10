using Rocchini.Services.Identity.Domain.Models;
using System;
using System.Threading.Tasks;

namespace Rocchini.Services.Identity.Domain.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetAsync(Guid id);
        Task<User> GetAsync(string email);
        Task AddAsync(User user);
    }
}
