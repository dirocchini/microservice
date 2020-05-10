using MongoDB.Driver;
using MongoDB.Driver.Linq;
using Rocchini.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rocchini.Api.Repository
{
    public class ActivityRepository : IActivityRepository
    {
        private readonly IMongoDatabase mongoDatabase;

        public ActivityRepository(IMongoDatabase mongoDatabase)
        {
            this.mongoDatabase = mongoDatabase;
        }


        public async Task AddAsync(Activity model) => await Collection.InsertOneAsync(model);


        public async Task<IEnumerable<Activity>> BrowseAsync(Guid userId) => await Collection.AsQueryable().Where(a => a.UserId == userId).ToListAsync();


        public async Task<Activity> GetAsync(Guid id) => await Collection.AsQueryable().FirstOrDefaultAsync(a => a.Id == id);
        

        private IMongoCollection<Activity> Collection => mongoDatabase.GetCollection<Activity>("Activities");

    }
}
