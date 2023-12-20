using DaneshakrShop.Application.IServices;
using DaneshakrShop.Application.Services;
using DaneshkarShop.Domain.IRepository;
using Infra.Data.AppDbContext;
using Infra.Data.Repository;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;

namespace DaneshkarShop.Presentation
{
    public class Program
    {
        public static void Main(string[] args)
        {
            #region Builder

            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<IUserRepository,UserRepository>();


            #region Context

            builder.Services.AddDbContext<DaneshkarAppDbContext>(op =>
               op.UseSqlite(builder.Configuration.GetConnectionString("AppDbContext")));

            #endregion

            #region Authentication

            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            })
                // Add Cookie settings
                .AddCookie(options =>
                {
                    options.LoginPath = "/Account/Login";
                    options.LogoutPath = "/Logout";
                    options.ExpireTimeSpan = TimeSpan.FromDays(30);
                });

            #endregion

            var app = builder.Build();

            #endregion

            #region App Services

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "MyAreas",
                    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
                );
                endpoints.MapControllerRoute(
                    name: "Default",
                    pattern: "{controller=Home}/{action=Index}/{id?}"
                );
            });

            app.Run();

            #endregion

        }
    }
}