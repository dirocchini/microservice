using Rocchini.Services.Activities.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Rocchini.Services.Activities.Domain.Repositories
{
    public interface ICategoryRepository
    {
        Task<Category> GetAsync(string name);
        Task<IEnumerable<Category>> BrowseAsync(string name);
        Task AddAsync(Category category);
    }
}
