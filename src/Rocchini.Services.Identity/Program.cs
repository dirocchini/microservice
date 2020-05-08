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
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
