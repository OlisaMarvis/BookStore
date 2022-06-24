using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Marvis.BookStore
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
            services.AddRazorPages();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public async void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseRouting();

            //app.UseStaticFiles();



            //app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.Map("/", async context =>
                {
                    //if (env.IsDevelopment())
                    //{
                    //await context.Response.WriteAsync("Hello from dev");
                    //}
                    //else if (env.IsProduction())
                    //{
                    //    await context.Response.WriteAsync("Hello from prod");
                    //}
                    //else if (env.IsStaging())
                    //{
                    //    await context.Response.WriteAsync("Hello from stag");
                    //}
                    //else
                    //await context.Response.WriteAsync(env.EnvironmentName);

                    //Checking for the name of our custom environment
                    if (env.IsEnvironment("Develop"))
                    {
                        await context.Response.WriteAsync("Hello from custom Name");
                    }
                    else
                        await context.Response.WriteAsync(env.EnvironmentName);
                });
                //endpoints.MapRazorPages();
            });

            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.Map("/Marvis", async context =>
            //    {
            //        await context.Response.WriteAsync("Hello Marvi);
            //    });
            //    //endpoints.MapRazorPages();
            //});
           
        }
    }
}
