using System.Threading.Tasks;

namespace Rocchini.Common.Mongo
{
    public interface IDatabaseSeeder
    {
        Task SeedAsync();
    }
}
