using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Options;
using Project.DataBase;
using Project.Entities;

namespace Project.App
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
            services.AddDbContext<Context>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            //UseSqlServer(@"Server=vct.vk;Database=db_Gavrilov;User Id=t154328;Password=t154328;");
            //UseSqlServer(@"Server=www.vk.edu.ee;Database=db_Gavrilov;User Id=t154328;Password=t154328;");

            services.AddDbContext<LocalizationContext>(options => options.UseSqlServer(Configuration.GetConnectionString("LocalizationConnection")));

            services.AddTransient<IStringLocalizer, AppStringLocalizer>();
            services.AddSingleton<IStringLocalizerFactory>(new AppStringLocalizerFactory(Configuration.GetConnectionString("LocalizationConnection")));

            services.AddIdentity<User, IdentityRole>(opts =>
            {
                opts.User.RequireUniqueEmail = true;
            })
                .AddEntityFrameworkStores<Context>();

            //services.AddLocalization(options => options.ResourcesPath = "Resources");
            services.AddMvc()
                .AddDataAnnotationsLocalization(options => {
                    options.DataAnnotationLocalizerProvider = (type, factory) =>
                    factory.Create(null);
                })
                .AddViewLocalization();
            services.Configure<RequestLocalizationOptions>(options =>
            {
                var supportedCultures = new[]
                {
                    new CultureInfo("en"),
                    new CultureInfo("et"),
                    new CultureInfo("ru")
                };

                options.DefaultRequestCulture = new RequestCulture("et");
                options.SupportedCultures = supportedCultures;
                options.SupportedUICultures = supportedCultures;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            var locOptions = app.ApplicationServices.GetService<IOptions<RequestLocalizationOptions>>();
            app.UseRequestLocalization(locOptions.Value);

            app.UseStaticFiles();


            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
