using Microsoft.Extensions.Logging;
using RawRabbit;
using Rocchini.Common.Commands;
using Rocchini.Common.Commands.Interfaces;
using Rocchini.Common.Events;
using Rocchini.Common.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rocchini.Services.Identity.Handlers
{
    public class CreateUserHandler : ICommandHandler<CreateUser>
    {
        private readonly IBusClient _busClient;
        private ILogger<CreateUserHandler> _logger;

        public CreateUserHandler(IBusClient busClient, ILogger<CreateUserHandler> logger)
        {
            _busClient = busClient;
            _logger = logger;
        }

        public async Task HandleAsync(CreateUser command)
        {
            _logger.LogInformation($"Creating User: {@command.Email} {@command.Name}");

            try
            {
                //await _userService.RegisterAsync(command.Name, command.Email, command.Password);
                // Fire event by putting event into the queue.
                await _busClient.PublishAsync(new UserCreated(command.Email, command.Name));
            }
            catch (RocchiniException ex)
            {
                await _busClient.PublishAsync(new CreateUserRejected(command.Email, ex.Code, ex.Message));
                _logger.LogError(ex.Message);
            }
            catch (Exception ex)
            {
                await _busClient.PublishAsync(new CreateUserRejected(command.Email, "Unexpected error", ex.Message));
                _logger.LogError(ex.Message);
            }
        }
    }
}
