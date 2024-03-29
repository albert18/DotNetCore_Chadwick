using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExploreCalifornia.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;

namespace ExploreCalifornia
{
    public class Startup
    {
        //private readonly IConfiguration configuration;

        //public Startup(IConfiguration configuration)
        //{
        //    this.configuration = configuration;
        //}

        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }


        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<FeatureToggles>(x => new FeatureToggles {
                DeveloperExceptions = Configuration.GetValue<bool>("FeatureToggles:DeveloperExceptions")
            });

            services.AddDbContext<BlogDataContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            //Add database
            //services.AddDbContext<BlogDataContext>(options =>
            //{
            //    var connectionString = configuration.GetConnectionString("BlogDataContext");
            //    options.UseSqlServer(connectionString);
            //});

            //Adding MVC
            services.AddMvc(option => option.EnableEndpointRouting = false);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, FeatureToggles features)
        {
            //ERROR must go to properties > Debug and change enviroment
            app.UseExceptionHandler("/error.html");

            if (features.DeveloperExceptions)
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapGet("/", async context =>
            //    {
            //        await context.Response.WriteAsync("HELLOW!");
            //    });
            //});


            #region Middleware App Use
            //app.Use(async (context, next) =>
            //{
            //    if (context.Request.Path.Value.StartsWith("/hello"))
            //    {
            //        await context.Response.WriteAsync("TEST Hello");
            //    }

            //    await next();
            //});

            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("TEST");
            //}); 
            #endregion

            #region Error - bad practice and security issue
            app.Use(async (context, next) =>
            {
                if (context.Request.Path.Value.Contains("invalid"))
                {
                    throw new Exception("ERROR!");
                }

                await next();
            });
            #endregion



            #region Adding MVC
            app.UseMvc(routes =>
            {
                routes.MapRoute("Default",
                    "{controller=Home}/{action=Index}/{id?}"
                );
            }); 
            #endregion


            #region When serving static files like CSS/Images - wwwroot
            app.UseFileServer(); 
            #endregion
        }
    }
}
