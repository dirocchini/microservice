using MongoDB.Driver;
using MongoDB.Driver.Linq;
using Rocchini.Services.Identity.Domain.Models;
using Rocchini.Services.Identity.Domain.Repositories;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Rocchini.Services.Identity.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IMongoDatabase _mongoDatabase;

        public UserRepository(IMongoDatabase mongoDatabase)
        {
            _mongoDatabase = mongoDatabase;
        }

        public async Task AddAsync(User user) => await Collection.InsertOneAsync(user);
        

        public async Task<User> GetAsync(Guid id) => await Collection.AsQueryable().FirstOrDefaultAsync(u => u.Id == id);
        

        public async Task<User> GetAsync(string email) => await Collection.AsQueryable().FirstOrDefaultAsync(u => u.Email == email.ToLowerInvariant());


        private IMongoCollection<User> Collection => _mongoDatabase.GetCollection<User>("Users");
    }
}
