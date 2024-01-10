using Inventory.Data.IRepo;
using Inventory.Data.Repo;
using Inventory.Dto;
using Inventory.Dto.Models;
using Inventory.Repo.IRepo;
using Inventory.Repo.Repo;
using Inventory.Services.IRepo;
using Inventory.Services.Repo;
using Inventory.Utility;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inventory
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
         //   var emailConfig = Configuration
         //.GetSection("EmailConfiguration")
         //.Get<EmailConfiguration>();
            //services.AddSingleton(emailConfig);
            services.AddControllersWithViews();
            //services.AddControllersWithViews(options =>
            //{
            //    options.Filters.Add(new CustomAuthorizationFilter());
            //});
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(o => o.LoginPath = new PathString("/Pages/SignIn"));
            services.AddAuthorization(options =>
            {
                options.AddPolicy("RequireAdministratorRole",
                     policy => policy.RequireRole("Admin", "User", "Manager", "Supervisor"));
            });
            
            var connectionStringProvider = new ConfigurationHelpers();
            var connectionString = connectionStringProvider.GetSetting("DefaultConnection");

            services.AddDbContext<InventoryManagementContext>(options => options.UseSqlServer(connectionString));
            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(20); // Set session timeout
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IPageData, PageData>();         
            services.AddScoped<ILoginPage, LoginPage>();
            //services.AddScoped<IEmailService, EmailService>();


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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSession();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Pages}/{action=SignIn}/{id?}");
            });
        }
    }
}
