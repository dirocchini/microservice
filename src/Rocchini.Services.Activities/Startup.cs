using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Rocchini.Common.Auth;
using Rocchini.Common.Commands;
using Rocchini.Common.Commands.Interfaces;
using Rocchini.Common.Mongo;
using Rocchini.Common.RabbitMq;
using Rocchini.Services.Activities.Domain.Repositories;
using Rocchini.Services.Activities.Handlers;
using Rocchini.Services.Activities.Repositories;
using Rocchini.Services.Activities.Services;
using Rocchini.Services.Activities.Services.Interfaces;

namespace Rocchini.Services.Activities
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddLogging();
            services.AddJwt(Configuration);
            services.AddMongoDb(Configuration);
            services.AddRabbitMq(Configuration);
            services.AddSingleton<ICommandHandler<CreateActivity>, CreateActivityHandler>();
            services.AddSingleton<IActivityRepository, ActivityRepository>();
            services.AddSingleton<ICategoryRepository, CategoryRepository>();
            services.AddSingleton<IDatabaseSeeder, CustomMongoSeeder>();
            services.AddSingleton<IActivityService, ActivityService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            //app.ApplicationServices.GetService<IDatabaseInitializer>().InitializerAsync();

            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                serviceScope.ServiceProvider.GetService<IDatabaseInitializer>().InitializeAsync();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
