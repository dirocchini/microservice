using MongoDB.Driver;
using Rocchini.Common.Mongo;
using Rocchini.Services.Activities.Domain.Models;
using Rocchini.Services.Activities.Domain.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rocchini.Services.Activities.Services
{
    public class CustomMongoSeeder : MongoSeeder
    {
        private readonly IMongoDatabase _mongoDatabase;
        private readonly ICategoryRepository _categoryRepository;

        public CustomMongoSeeder(IMongoDatabase mongoDatabase, ICategoryRepository categoryRepository) : base(mongoDatabase)
        {
            _mongoDatabase = mongoDatabase;
            _categoryRepository = categoryRepository;
        }

        protected override async Task CustomSeedAsync()
        {
            var categories = new List<string>
            {
                "work",
                "sport",
                "hobby"
            };

            await Task.WhenAll(categories.Select(c => _categoryRepository.AddAsync(new Category(c))));
        }
    }
}
