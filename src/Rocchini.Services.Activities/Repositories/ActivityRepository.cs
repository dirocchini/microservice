using MongoDB.Driver;
using MongoDB.Driver.Linq;
using Rocchini.Services.Activities.Domain.Models;
using Rocchini.Services.Activities.Domain.Repositories;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Rocchini.Services.Activities.Repositories
{
    public class ActivityRepository : IActivityRepository
    {
        private readonly IMongoDatabase _mongoDatabase;

        public ActivityRepository(IMongoDatabase mongoDatabase)
        {
            _mongoDatabase = mongoDatabase;
        }

        public async Task AddAsync(Activity activity) => await Collection.InsertOneAsync(activity);


        public async Task<Activity> GetAsync(Guid Id) => await Collection.AsQueryable().FirstOrDefaultAsync(x => x.Id == Id);
        

        private IMongoCollection<Activity> Collection => _mongoDatabase.GetCollection<Activity>("Activities");

    }
}
