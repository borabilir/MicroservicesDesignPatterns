using MassTransit;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Shared;
using Stock.API.Consumers;
using Stock.API.Models;

namespace Stock.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMassTransit(x =>
            {
                x.AddConsumer<OrderCreatedEventConsumer>();

                x.AddConsumer<StockRollbackMessageConsumer>();

                x.UsingRabbitMq((context, cfg) =>
                {
                    cfg.Host(Configuration.GetConnectionString("RabbitMQ"));

                    cfg.ReceiveEndpoint(RabbitMQSettings.StockOrderCreatedEventQueue, ep =>
                    {
                        ep.ConfigureConsumer<OrderCreatedEventConsumer>(context);
                    });

                    cfg.ReceiveEndpoint(RabbitMQSettings.StockRollbackMessageQueue, ep =>
                    {
                        ep.ConfigureConsumer<StockRollbackMessageConsumer>(context);
                    });
                });
            });

            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseInMemoryDatabase("StockDb");
            });

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Stock.API", Version = "v1" });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Stock.API v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
