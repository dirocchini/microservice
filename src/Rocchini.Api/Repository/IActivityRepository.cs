
using Rocchini.Api.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Rocchini.Api.Repository
{
    public interface IActivityRepository
    {
        Task<Activity> GetAsync(Guid id);
        Task AddAsync(Activity model);
        Task<IEnumerable<Activity>> BrowseAsync(Guid userId);
    }
}
