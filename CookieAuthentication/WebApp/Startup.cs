using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Security.Claims;
using WebApp.Business.Factories;
using WebApp.Core.Abstract;
using WebApp.Core.Services;
using WebApp.Model;

namespace WebApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    options.Cookie.Name = "WebApp.Cookie";
                    options.Cookie.SameSite = SameSiteMode.Strict;
                    options.Cookie.SecurePolicy = CookieSecurePolicy.None;
                    options.Cookie.HttpOnly = true;
                    options.LoginPath = new PathString($"/{ControllerNames.Login}/{ActionNames.Login}");
                    options.LogoutPath = new PathString($"/{ControllerNames.Login}/{ActionNames.LogOut}");
                    options.AccessDeniedPath = new PathString($"/{ControllerNames.Login}/{ActionNames.UserAccessDenied}");
                });

            services.AddAuthorization(config =>
            {
                config.AddPolicy($"{PolicyNames.Admin}", policyBuilder =>
                policyBuilder.RequireClaim(ClaimTypes.Role, $"{RoleNames.Admin}"));

                config.AddPolicy($"{PolicyNames.Customer}", policyBuilder =>
                policyBuilder.RequireClaim(ClaimTypes.Role, new string[] { $"{RoleNames.Admin}", $"{RoleNames.Customer}" }));
            });

            services.AddHttpContextAccessor();
            services.AddControllersWithViews();

            SetupDependencyInjection(services);
        }

        static void SetupDependencyInjection(IServiceCollection services)
        {
            services.AddTransient<IHttpContextAccessor, HttpContextAccessor>();
            services.AddTransient<IAuthenticationService, AuthenticationService>();
            services.AddTransient<IAuthentication, CookieAuthenticationService>();
            services.AddTransient<Business.Abstract.IAuthenticationService, Business.Services.AuthenticationService>();
            services.AddTransient<Business.Abstract.IAuthenticationModelFactory, AuthenticationModelFactory>();
            services.AddTransient<Business.Abstract.IModelFactory, ModelFactory>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public static void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            SetConfigurationBuilder(env);

            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseCookiePolicy();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }

        static void SetConfigurationBuilder(IWebHostEnvironment env)
        {
            new ConfigurationBuilder()
                  .SetBasePath(env.ContentRootPath)
                  .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                  .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                  .AddEnvironmentVariables();
        }
    }
}