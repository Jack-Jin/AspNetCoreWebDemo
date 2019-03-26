using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace AspNetCoreWebDemo
{
    public class Startup
    {
        private IConfiguration _config;

        public Startup(IConfiguration config)
        {
            _config = config;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
        }

        /* Demo #1, Pipline  
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILogger<Startup> logger)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.Use(async (context, next) =>
            {
                logger.LogInformation("MW1: Incoming Request");

                await next();

                logger.LogInformation("MW1: Outgoing Request");
            });

            app.Use(async (context, next) =>
            {
                logger.LogInformation("MW2: Incoming Request");

                await next();

                logger.LogInformation("MW2: Outgoing Request");
            });

            app.Run(async (context) =>
            {
                string showContent = "Hello World!";
                showContent += Environment.NewLine + System.Diagnostics.Process.GetCurrentProcess().ProcessName;
                showContent += Environment.NewLine + _config["MyKey"];

                await context.Response.WriteAsync(showContent);

                logger.LogInformation("MW3: Request handled and response produced");
            });
        }
        */

        /* Demo #2, Static file middleware
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILogger<Startup> logger)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            FileServerOptions fileServerOptions = new FileServerOptions();
            fileServerOptions.DefaultFilesOptions.DefaultFileNames.Clear();
            fileServerOptions.DefaultFilesOptions.DefaultFileNames.Add("foo.html");
            app.UseFileServer(fileServerOptions);

            //
            //app.UseDefaultFiles();
            //app.UseStaticFiles();

            app.Run(async (context) =>
            {
                string showContent = "Hello World!";
                showContent += Environment.NewLine + System.Diagnostics.Process.GetCurrentProcess().ProcessName;
                showContent += Environment.NewLine + _config["MyKey"];

                await context.Response.WriteAsync(showContent);
            });
        }
        */

        /* Demo #3, exceiption
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                DeveloperExceptionPageOptions developerExceptionPageOptions = new DeveloperExceptionPageOptions()
                {
                    SourceCodeLineCount = 10
                };
                app.UseDeveloperExceptionPage(developerExceptionPageOptions);
            }

            app.UseFileServer();

            app.Run(async (context) =>
            {
                throw new Exception("some error processing the request");

                string showContent = "Hello World!";
                await context.Response.WriteAsync(showContent);
            });
        }
        */

            /* Demo #4, environment name */
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else if(env.IsProduction() || env.IsStaging())
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseStaticFiles();

            app.Run(async (context) =>
            {
                string showContent = "Hosting Environment: " + env.EnvironmentName;   // from launchSettings.json(ASPNETCORE_ENVIRONMENT)
                await context.Response.WriteAsync(showContent);
            });

        }


    }
}
