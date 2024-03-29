﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TicketSellWebApp.Data;
using TicketSellWebApp.Models;
using TicketSellWebApp.Repositories.cs;
using TicketSellWebApp.Services;
using TicketSellWebApp.Repositories;
using TicketSellWebApp.Controllers;
using TicketSellWebApp.Middleware;

namespace TicketSellWebApp
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
            services.AddDbContext<UserContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("UserContext")));
            services.RegisterServiceDependencies();
            services.AddControllersWithViews();
        }
        private void UpgradeDatabase(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<UserContext>();
                if (context != null && context.Database != null)
                {
                    context.Database.Migrate();
                }
            }
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            UpgradeDatabase(app);
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

            app.UseMiddleware<ApiKeyMiddleware>();
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
    public static class DependencyInjector
    {
        public static IServiceCollection RegisterServiceDependencies(this IServiceCollection services, int i = 0)
        {
            // repository    
            services.AddScoped<IRepository<User>, UserRepository>();
            services.AddScoped<ITicketRepository<Ticket>, TicketRepository>();
            services.AddScoped<IRepository<Show>, ShowRepository>();
            //services
            services.AddScoped<IService<User>, UserService>();
            services.AddScoped<ITicketService<Ticket>, TicketService>();
            services.AddScoped<IService<Show>, ShowService>();
            services.AddScoped<ICookieService, CookieService>();
            //services.AddScoped<IMasterMenuProvider, MasterMenuProvider>();
            return services;
        }
    }
}
