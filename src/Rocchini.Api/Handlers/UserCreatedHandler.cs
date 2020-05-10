using Rocchini.Common.Events;
using Rocchini.Common.Events.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Rocchini.Api.Handlers
{
    public class UserCreatedHandler : IEventHandler<UserCreated>
    {
        public async Task HandleAsync(UserCreated @event)
        {
            Thread.Sleep(1000);
            await Task.CompletedTask;
            Console.WriteLine($"User Created: {@event.Email} ON {DateTime.Now}");
        }
    }
}
