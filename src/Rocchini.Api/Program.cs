using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Rocchini.Common.Events;
using Rocchini.Common.Service;
using System.Threading.Tasks;

namespace Rocchini.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ServiceHost.Create<Startup>(args)
                .UserRabbitMq()
                .SubscribeToEvent<ActivityCreated>()
                .Build()
                .Run();
        }
  
    }
}
