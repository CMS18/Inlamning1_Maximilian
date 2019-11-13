using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AlmApp.Web.Data;
using AlmApp.Web.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace AlmApp.Web
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
            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IServiceProvider services)
        {
           var customers = CreateCustomers();
           BankRepository.AddCustomers(customers);



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

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }

        public List<Customer> CreateCustomers()
        {
            var customers = new List<Customer>();

            var gabriel = new Customer
            {
                Id = 1,
                Name = "Gabriel",
                Account = new Account(1, 500)
            };

            var amanda = new Customer
            {
                Id = 2,
                Name = "Amanda",
                Account = new Account(2, 1500)
            };

            var max = new Customer
            {
                Id = 3,
                Name = "Max",
                Account = new Account(3, 2500)
            };

            customers = new List<Customer>
            {
                gabriel, amanda, max
            };

            return customers;
        }
    }
}
