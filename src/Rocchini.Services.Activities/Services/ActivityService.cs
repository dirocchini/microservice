using Rocchini.Common.Exceptions;
using Rocchini.Services.Activities.Domain.Models;
using Rocchini.Services.Activities.Domain.Repositories;
using Rocchini.Services.Activities.Services.Interfaces;
using System;
using System.Threading.Tasks;

namespace Rocchini.Services.Activities.Services
{
    public class ActivityService : IActivityService
    {
        private readonly IActivityRepository _activityRepository;
        private readonly ICategoryRepository _categoryRepository;

        public ActivityService(IActivityRepository activityRepository, ICategoryRepository categoryRepository)
        {
            _activityRepository = activityRepository;
            _categoryRepository = categoryRepository;
        }

        public async Task AddAsync(Guid id, Guid userId, string category, string name, string description, DateTime createdOn)
        {
            var activityCategory = await _categoryRepository.GetAsync(category);
            if (activityCategory == null)
                throw new RocchiniException("activity_not_found", $"Category {category} was not found");

            var activity = new Activity(id, name, activityCategory, description, userId, createdOn);
            await _activityRepository.AddAsync(activity);
        }
    }
}
