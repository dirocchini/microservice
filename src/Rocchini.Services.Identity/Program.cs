using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Rocchini.Common.Commands;
using Rocchini.Common.Service;

namespace Rocchini.Services.Identity
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ServiceHost.Create<Startup>(args)
                .UserRabbitMq()
                .SubscribeToCommand<CreateUser>()
                .Build()
                .Run();
        }

    }
}
