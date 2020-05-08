using Microsoft.AspNetCore.Hosting;
using RawRabbit;

namespace Rocchini.Common.Service
{
    public partial class ServiceHost
    {
        public class HostBuilder : BuilderBase
        {
            private readonly IWebHost _webHost;
            private IBusClient _busClient;

            public HostBuilder(IWebHost webHost)
            {
                _webHost = webHost;
            }

            public BusBuilder UserRabbitMq()
            {
                _busClient =(IBusClient)_webHost.Services.GetService(typeof(IBusClient));
                return new BusBuilder(_webHost, _busClient);
            }

            public override ServiceHost Build()
            {
                return new ServiceHost(_webHost);
            }
        }

    }
}
