using Rocchini.Services.Activities.Domain.Models;
using System;
using System.Threading.Tasks;

namespace Rocchini.Services.Activities.Domain.Repositories
{
    public interface IActivityRepository
    {
        Task<Activity> GetAsync(Guid Id);
        Task AddAsync(Activity activity);
    }
}
