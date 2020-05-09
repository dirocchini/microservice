using Microsoft.Extensions.Options;
using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Rocchini.Common.Mongo
{
    public class MongoInitializer : IDatabaseInitializer
    {
        private bool _initialized;
        private readonly bool _seed;
        private readonly IMongoDatabase _database;

        public MongoInitializer(IMongoDatabase database, IOptions<MongoOptions> options)
        {
            _database = database;
            _seed = options.Value.Seed;
        }
        public async Task InitializerAsync()
        {
            if (_initialized)
                return;

            RegisterConventions();
            _initialized = true;

            if (!_seed)
                return;
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
