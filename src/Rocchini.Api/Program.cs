using Rocchini.Common.Events;
using Rocchini.Common.Service;

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
