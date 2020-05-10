using System;
using System.Threading.Tasks;

namespace Rocchini.Services.Activities.Services.Interfaces
{
    public interface IActivityService
    {
        Task AddAsync(Guid id, Guid userId, string category, string name, string description, DateTime createdOn); 
    }
}
