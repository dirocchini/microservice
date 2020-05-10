using Rocchini.Api.Models;
using Rocchini.Api.Repository;
using Rocchini.Common.Events;
using Rocchini.Common.Events.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Rocchini.Api.Handlers
{
    public class ActivityCreatedHandler : IEventHandler<ActivityCreated>
    {
        private readonly IActivityRepository activityRepository;

        public ActivityCreatedHandler(IActivityRepository activityRepository)
        {
            this.activityRepository = activityRepository;
        }



        public async Task HandleAsync(ActivityCreated @event)
        {
            Thread.Sleep(1000);
            await activityRepository.AddAsync(new Activity
            {
                Id = @event.Id,
                Category = @event.Category,
                Name = @event.Name,
                Description = @event.Description,
                UserId = @event.UserId,
                CreatedOn = @event.CreatedAt
            });
            Console.WriteLine($"Activity Created: {@event.Name} ON {DateTime.Now}");
        }
    }
}
