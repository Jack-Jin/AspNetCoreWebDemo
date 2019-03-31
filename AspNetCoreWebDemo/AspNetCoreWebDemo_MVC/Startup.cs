using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreWebDemo_MVC.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace AspNetCoreWebDemo_MVC
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().AddXmlSerializerFormatters();
            //services.AddMvc()
            //services.AddMvcCore();

            /* **************************************************************************************************************
             * Singleton objects are the same for every object and every request.
             * Transient objects are always different; a new instance is provided to every controller and every service. 
             * Scoped objects are the same within a request, but different across different requests. 
             ****************************************************************************************************************/
            services.AddSingleton<IEmployeeRepository, MockEmployeeRepository>();
            //services.AddTransient<IEmployeeRepository, MockEmployeeRepository>();
            //services.AddScoped<IEmployeeRepository, MockEmployeeRepository>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();

            /* Default setting MVC route setting */ 
            //app.UseMvcWithDefaultRoute();

            /* For Conventional routes setting */
            app.UseMvc(routes =>
            {
                routes.MapRoute("default", "vv/{controller=Home}/{action=Index}/{id?}");
            });

            /* For attribute routes settings */
            //app.UseMvc(); 

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hello World!");
            });
        }
    }
}
