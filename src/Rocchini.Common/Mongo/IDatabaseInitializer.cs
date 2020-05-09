using System.Threading.Tasks;

namespace Rocchini.Common.Mongo
{
    public interface IDatabaseInitializer
    {
        Task InitializeAsync();
    }
}
