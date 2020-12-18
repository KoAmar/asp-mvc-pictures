using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WebApplicationMVC.Models;

namespace WebApplicationMVC
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // ReSharper disable once MemberCanBePrivate.Global
        // ReSharper disable once UnusedAutoPropertyAccessor.Global
        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<AppDbContext>();
            services.AddScoped<IPostRepository, SqlPostRepos>();
            services.AddScoped<ICommentsRepository, SqlCommentsRepos>();
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(
                //"Data Source=PORTABLE-LAPTOP;Integrated Security=True;database=BlogDb"
                //"Data Source=(localdb)\\MSSQLLocalDB;Integrated Security=True;database=BlogDb"
                Configuration.GetConnectionString("local")
                ));
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, AppDbContext db)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseStatusCodePagesWithReExecute("/Error/{0}");
                //app.UseStatusCodePages();
                app.UseHsts();
            }

            db.Database.EnsureCreated();

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("default", "{controller=Posts}/{action=Index}/{id?}");
            });
        }
    }
}