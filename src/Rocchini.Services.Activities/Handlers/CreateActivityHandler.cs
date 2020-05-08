using RawRabbit;
using Rocchini.Common.Commands;
using Rocchini.Common.Commands.Interfaces;
using Rocchini.Common.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Rocchini.Services.Activities.Handlers
{
    public class CreateActivityHandler : ICommandHandler<CreateActivity>
    {
        private readonly IBusClient _busClient;

        public CreateActivityHandler(IBusClient busClient)
        {
            _busClient = busClient;
        }


        public async Task HandleAsync(CreateActivity command)
        {
            Console.WriteLine($"Creating Activity: {command.Name} ON {DateTime.Now}");
            Thread.Sleep(1000);
            await _busClient.PublishAsync(new ActivityCreated(command.Id, command.UserId, command.Category, command.Name, command.Description, command.CreatedAt));
        }
    }
}
