using BusinessLogic;
using DataAccess;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;


namespace StoreWebUI
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
            services.AddDbContext<StoreAppDatabaseContext>(options => options.UseSqlServer(Configuration.GetConnectionString("Reference2DB")));
            services.AddScoped<CustomerBL>();
            services.AddScoped<ProductBL>();
            services.AddScoped<InventoryBL>();
            services.AddScoped<LineItemBL>();
            services.AddScoped<StoreBL>();
            services.AddScoped<OrderBL>();
            services.AddScoped<IRepository, RepositoryCloud>();
            services.AddControllersWithViews().AddRazorRuntimeCompilation();

            services.AddDistributedMemoryCache();

            // add support for razor pages
            services.AddRazorPages();

            services.AddSession(options =>
            {

                services.AddSession(options =>
                {
                    options.Cookie.Name = ".AdventureWorks.Session";

                    //default session time out is 20 minutes
                    //but we can set it to any time span
                    options.IdleTimeout = TimeSpan.FromSeconds(30);

                    //allows to use the session cookie
                    //even if the user hasn't consented
                    options.Cookie.IsEssential = true;
                });
            });
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

            app.UseRouting();

            app.UseAuthorization();

            // allow to manage user session data
            app.UseSession();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });

        }
    }
}

