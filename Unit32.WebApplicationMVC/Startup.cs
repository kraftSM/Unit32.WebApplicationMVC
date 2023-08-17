using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Unit32.WebApplicationMVC.DL;
using Unit32.WebApplicationMVC.Middlewares;
using Unit32.WebApplicationMVC.Models;

namespace Unit32.WebApplicationMVC
{
    public class Startup
    {
        static IWebHostEnvironment _env;
        
        public IConfiguration _configuration { get; }

        public Startup(IWebHostEnvironment env, IConfiguration configuration)
        {
            _env =env;
            _configuration = configuration;
        }

       

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Присоединяем контест БД
            string connection = _configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<BlogContext>(options => options.UseSqlServer(connection), ServiceLifetime.Singleton);
            //services.AddDbContext<BlogContext>(options => options.UseSqlServer(connection));
            //services.AddSingleton<ILoggingRepository, LoggingRepository>();

            // регистрация сервисы репозиториев для взаимодействия с базой данных
            //service for Blogs
            services.AddSingleton<IBlogRepository, BlogRepository>();

            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();
            app.UseMiddleware<LoggingMiddleware>();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
