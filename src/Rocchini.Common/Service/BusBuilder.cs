using Microsoft.AspNetCore.Hosting;
using RawRabbit;
using Rocchini.Common.Commands.Interfaces;
using Rocchini.Common.Events.Interfaces;
using Rocchini.Common.RabbitMq;

namespace Rocchini.Common.Service
{
    public partial class ServiceHost
    {
        public class BusBuilder : BuilderBase
        {
            private readonly IWebHost _webHost;
            private readonly IBusClient _busClient;

            public BusBuilder(IWebHost webHost, IBusClient busClient)
            {
                _webHost = webHost;
                _busClient = busClient;
            }

            public BusBuilder SubscribeToCommand<TCommand> () where TCommand : ICommand
            {
                var handler = (ICommandHandler<TCommand>)_webHost.Services.GetService(typeof(ICommandHandler<TCommand>));
                _busClient.WithCommandHandlerAsync(handler);

                return this;
            }

            public BusBuilder SubscribeToEvent<TEvent>() where TEvent : IEvent
            {
                var rrr = typeof(TEvent);
                var handler = (IEventHandler<TEvent>)_webHost.Services.GetService(typeof(IEventHandler<TEvent>));
                _busClient.WithEventHandlerAsync(handler);

                return this;
            }

            public override ServiceHost Build()
            {
                return new ServiceHost(_webHost);
            }
        }

    }
}
