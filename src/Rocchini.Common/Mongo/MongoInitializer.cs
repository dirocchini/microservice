using Microsoft.Extensions.Options;
using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Rocchini.Common.Mongo
{
    public class MongoInitializer : IDatabaseInitializer
    {
        private bool _initialized;
        private readonly bool _seed;
        private readonly IMongoDatabase _database;
        private readonly IDatabaseSeeder _databaseSeeder;

        public MongoInitializer(IMongoDatabase database, IOptions<MongoOptions> options, IDatabaseSeeder databaseSeeder)
        {
            _database = database;
            _databaseSeeder = databaseSeeder;
            _seed = options.Value.Seed;
        }
        public async Task InitializeAsync()
        {
            if (_initialized)
                return;

            RegisterConventions();
            _initialized = true;

            if (!_seed)
                return;

            await _databaseSeeder.SeedAsync();
        }

        private void RegisterConventions()
        {
            ConventionRegistry.Register("RocchiniConventions", new MongoConvention(), x => true);
        }


    }

    internal class MongoConvention : IConventionPack
    {
        public IEnumerable<IConvention> Conventions => new List<IConvention>
        {
            new IgnoreExtraElementsConvention(true),
            new EnumRepresentationConvention(MongoDB.Bson.BsonType.String),
            new CamelCaseElementNameConvention()
        };
    }
}
