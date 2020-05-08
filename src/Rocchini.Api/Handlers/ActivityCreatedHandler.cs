using Rocchini.Common.Events;
using Rocchini.Common.Events.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Rocchini.Api.Handlers
{
    public class ActivityCreatedHandler : IEventHandler<ActivityCreated>
    {
        public async Task HandleAsync(ActivityCreated @event)
        {
            Thread.Sleep(1000);
            await Task.CompletedTask;
            Console.WriteLine($"Activity Created: {@event.Name} ON {DateTime.Now}");
        }
    }
}
