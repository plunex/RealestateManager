using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RealestateManager.Web.Core;
using GraphiQl;
using Microsoft.AspNetCore.Mvc;
using RealestateManager.Web.Core.Repository.Contracts;
using RealestateManager.Web.Core.Repository;
using GraphQL.Types;
using GraphQL;
using RealestateManager.Web.Core.Types;
using RealestateManager.Web.Core.Inputs;
using RealestateManager.Web.Services.Queries;
using RealestateManager.Web.Services.Mutation;
using RealestateManager.Web.Services.Schema;

namespace RealestateManager.Web
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
            services
               .AddMvc(options =>
               {
                   options.EnableEndpointRouting = false;
               })
               .SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
            services.AddMvc();


            services.AddTransient<IPropertyRepository, PropertyRepository>();
            services.AddTransient<IPaymentRepository, PaymentRepository>();

            services.AddDbContext<RealEstateContext>(options =>
                            options.UseSqlServer(
                                Configuration.GetConnectionString("DefaultConnection")));

            services.AddSingleton<IDocumentExecuter, DocumentExecuter>();
           
            services.AddScoped<PropertyQuery>();
            services.AddScoped<PropertyMutation>();
            services.AddScoped<PropertyInputType>();
            services.AddScoped<PaymentType>();
            services.AddScoped<PropertyType>();

            var sp = services.BuildServiceProvider();
            services.AddSingleton<ISchema>(new RealEstateSchema(new FuncDependencyResolver(type => sp.GetService(type))));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, RealEstateContext db)
        {
            if (env.IsDevelopment())
            {
                app.UseDatabaseErrorPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();


            app.UseGraphiQl();
            app.UseMvc();


            db.EnsureSeedData();
        }
    }
}
