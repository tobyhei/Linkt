using Linkt.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;

namespace Linkt
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Environment = System.Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            Configuration = configuration;
        }

        public string Environment { get; }
        public IConfiguration Configuration { get; private set; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            services.ConfigureDynamoDb(Environment == "Development");

            services.AddSingleton<LinkRepository>();

            services.AddSwaggerGen(c => c.SwaggerDoc("v1", new Info { Version = "v1", Title = "Linkt API" }));
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseMvc();

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Linkt API V1");
            });
        }
    }
}
