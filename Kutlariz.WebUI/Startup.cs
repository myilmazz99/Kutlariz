using System;
using AutoMapper;
using Kutlariz.Business.Logging;
using Kutlariz.Business.Mapper.AutoMapper;
using Kutlariz.Core.Entities;
using Kutlariz.DataAccess.Concrete.EntityFramework;
using Kutlariz.DataAccess.Concrete.Identity;
using Kutlariz.WebUI.Infrastructure;
using Kutlariz.WebUI.Seeds;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace Kutlariz.WebUI
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
            services.AddAutoMapper(typeof(MappingProfile));

            services.AddDbContext<IdentityContext>(options => options.UseSqlServer(@"Server=arya.veridyen.com\MSSQLSERVER2016;Database=kutlariz;User Id=myyilmaz_admin;Password=Bilelimadmin1;"));
            services.AddDbContext<KutlarizContext>(options => options.UseSqlServer(@"Server=arya.veridyen.com\MSSQLSERVER2016;Database=kutlariz;User Id=myyilmaz_admin;Password=Bilelimadmin1;"));
            services.AddIdentity<ApplicationUser, IdentityRole>(opt =>
            {
                opt.User.AllowedUserNameCharacters = "abcçdefgğhıijklmnoöpqrstuüvwxyzABCÇDEFGĞHIİJKLMNOÖPQRSTUÜVWXYZ0123456789-._@+";
                opt.Password.RequireDigit = false;
                opt.Password.RequireUppercase = false;
                opt.Password.RequireNonAlphanumeric = false;
                opt.Password.RequiredLength = 6;
                opt.User.RequireUniqueEmail = true;

                opt.Lockout.MaxFailedAccessAttempts = 5;
            }).AddEntityFrameworkStores<IdentityContext>().AddDefaultTokenProviders();

            services.ConfigureApplicationCookie(opt =>
            {
                opt.LoginPath = "/account/login";
                opt.AccessDeniedPath = "/account/accessdenied";
                opt.LogoutPath = "/account/logout";
                opt.ExpireTimeSpan = TimeSpan.FromDays(3);
                opt.Cookie = new CookieBuilder { HttpOnly = true, MaxAge = TimeSpan.FromDays(3), SameSite = SameSiteMode.Strict };
            });

            services.AddControllersWithViews();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerService logger, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {

            app.UseStatusCodePagesWithRedirects("/Error/{0}");

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler(logger);
            }


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

            IdentitySeed.Seed(userManager, roleManager).Wait();
        }
    }
}
