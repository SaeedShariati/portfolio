using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using portfolio.Models;
using portfolio.Models.Authentication;

namespace portfolio
{
    public class Startup
    {
        readonly IConfiguration Configuration;
        public Startup(IConfiguration config)
        {
            Configuration = config;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddTransient<IPostRepository, EFPostRepository>();
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(Configuration["Data:CSharpLearnPosts:ConnectionString"]));
            services.AddDbContext<ApplicationIdentityDbContext>(options => options.UseSqlServer(
                Configuration["Data:Identity:ConnectionString"]
                ));
            services.AddIdentity<User, IdentityRole>(options =>
            {
                options.SignIn.RequireConfirmedAccount = false;
                options.Password.RequireDigit = true;
                options.Password.RequireNonAlphanumeric = false;
                options.User.AllowedUserNameCharacters 
                += "شسیبلتانمکگپظطزرذدئوضصثقفغعهخحجچ۰۱۲۳۴۵۶۷۸۹";
            }).AddEntityFrameworkStores<ApplicationIdentityDbContext>();
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie("Cookies",options => {
                    options.Cookie.SameSite = SameSiteMode.Strict;
                });
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseStatusCodePages();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
