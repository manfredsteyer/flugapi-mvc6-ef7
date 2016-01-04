using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.AspNet.Http;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.SwaggerGen;
using Newtonsoft.Json;

namespace Sample
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().AddJsonOptions(options => {
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                options.SerializerSettings.Formatting = Formatting.Indented;
                // options.SerializerSettings.TypeNameHandling = TypeNameHandling.Objects;
            });

            services.AddCors();

            services.AddSwaggerGen();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app)
        {
            //app.UseIISPlatformHandler();

            // Alle Erlauben
            // app.UseCors(config => config.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

            var origins = new [] { "http://localhost:8080" };
            app.UseCors(config => config.WithOrigins(origins).AllowAnyMethod().AllowAnyHeader());

            app.UseStaticFiles();

            app.UseMvc(routes => {
                routes.MapRoute(
                        "default",
                        "{controller=Home}/{action=Index}/{id?}");
            });

            app.UseSwaggerGen();
            app.UseSwaggerUi();
        }

        // Entry point for the application.
        public static void Main(string[] args) => WebApplication.Run<Startup>(args);
    }
}
