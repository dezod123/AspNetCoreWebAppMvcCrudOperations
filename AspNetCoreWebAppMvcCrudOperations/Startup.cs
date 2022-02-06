using AspNetCoreWebAppMvcCrudOperations.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreWebAppMvcCrudOperations
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        //this is the dependency injection container, this is where we implement our services. 
        public void ConfigureServices(IServiceCollection services)
        {
            //setting up our connection string so we can use our DbContext
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"))
            );
            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        //this is where we can add our middleware. The request goes through the pipeline one way passes by one middleware
        //To the next one. Ie, goes from authentication, if authentication says its fine then goes to redirection... until it comes
        // to the end point. Then it returns the response to the server.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();

            //this for example enables wwwroot folder and it's files
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            //Controller is set to home by default, and the action is set to index by default. Id is optional.  In the URL
            //If we dont pass a controller, or action
            //it is going to use this default. 
            app.UseEndpoints(endpoints =>
            {
                //the ? in id? makes it optional
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
