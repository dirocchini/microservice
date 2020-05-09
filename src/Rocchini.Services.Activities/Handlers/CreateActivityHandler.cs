using DnsClient.Internal;
using RawRabbit;
using Rocchini.Common.Commands;
using Rocchini.Common.Commands.Interfaces;
using Rocchini.Common.Events;
using Rocchini.Common.Exceptions;
using Rocchini.Services.Activities.Services.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Rocchini.Services.Activities.Handlers
{
    public class CreateActivityHandler : ICommandHandler<CreateActivity>
    {
        private readonly IBusClient _busClient;
        private readonly IActivityService _activityService;
        private ILogger _logger;

        public CreateActivityHandler(IBusClient busClient, IActivityService activityService, ILogger logger)
        {    
            _busClient = busClient;
            _activityService = activityService;
            _logger = logger;
        }


        public async Task HandleAsync(CreateActivity command)
        {
            _logger.LogInformation($"Creating Activity: {command.Name} ON {DateTime.Now}");

            try
            {
                Thread.Sleep(1000);
                await _activityService.AddAsync(command.Id, command.UserId, command.Category, command.Name, command.Description, command.CreatedAt);
                await _busClient.PublishAsync(new ActivityCreated(command.Id, command.UserId, command.Category, command.Name, command.Description, command.CreatedAt));
                return;
            }
            catch (RocchiniException ex)
            {
                await _busClient.PublishAsync(new CreateActivityRejected(command.Id, ex.Code, ex.Message));
                _logger.LogError(ex.Message);
            }
            catch (Exception ex)
            {
                await _busClient.PublishAsync(new CreateActivityRejected(command.Id, "unexpected_error", ex.Message));
                _logger.LogError(ex.Message);
            }
        }
    }
}
