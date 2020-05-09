using MongoDB.Driver;
using MongoDB.Driver.Linq;
using Rocchini.Services.Activities.Domain.Models;
using Rocchini.Services.Activities.Domain.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rocchini.Services.Activities.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly IMongoDatabase _mongoDatabase;

        public CategoryRepository(IMongoDatabase mongoDatabase)
        {
            _mongoDatabase = mongoDatabase;
        }


        public async Task<Category> GetAsync(string name) => await Collection.AsQueryable().FirstOrDefaultAsync(x => x.Name == name.ToLowerInvariant());


        public async Task AddAsync(Category category) => await Collection.InsertOneAsync(category);

        public async Task<IEnumerable<Category>> BrowseAsync(string name) => await Collection.AsQueryable().ToListAsync();

        private IMongoCollection<Category> Collection => _mongoDatabase.GetCollection<Category>("Categories");
    }
}
