using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using BookStoreApp.Repository.DataAccess.SQL.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using BookStoreApp.Contracts.Interface;
using BookStoreApp.Domain;
using BookStoreApp.BookStore.CustomBinder;
using Microsoft.AspNetCore.Identity;
using BookStoreApp.Contracts.Models;

namespace BookStoreApp.BookStore
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddDbContext<BookStoreContext>(opt => opt.UseSqlServer(Configuration.GetConnectionString("BookStoreConnection")));

            services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<BookStoreContext>();
            services.AddCloudscribePagination();
            
#if DEBUG
            services.AddRazorPages().AddRazorRuntimeCompilation();
#endif
            services.AddTransient<IBookData, BookData>();
            services.AddTransient<IAccountData, AccountData>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseStaticFiles();
            app.UseAuthentication();

            app.UseRouting();
            app.UseEndpoints(endpoint =>
            {
                endpoint.MapDefaultControllerRoute();
                endpoint.MapControllerRoute(
                    name: "MyArea",
                    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");
            });
            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapControllerRoute(
            //        name: "default",
            //        pattern: "{controller=Book}/{action=Index}/");
            //});

        }
    }
}
