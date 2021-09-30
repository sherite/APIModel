namespace APIGSCore
{
    using Autofac;
    using Autofac.Extensions.DependencyInjection;

    using BRL.Managers;

    using Common;

    using DAL;

    using Entities.DTOs;
    using Entities.Models;

    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Http;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using Microsoft.Extensions.Logging;
    using Microsoft.OpenApi.Models;

    using System;

    using UI;

    /// <summary>
    /// The Startup class configures services and the app's request pipeline.
    /// </summary>
    public class Startup
    {

        private string version = string.Empty;
        /// <summary>
        /// Class's constructor
        /// </summary>
        /// <param name="configuration">instance of IConfiguration interface</param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary>
        /// Configuration method
        /// </summary>
        public IConfiguration Configuration { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public ILifetimeScope AutofacContainer { get; private set; }


        /// <summary>
        ///This method gets called by the runtime. Use this method to add services to the container. 
        /// </summary>
        /// <param name="services">service collection</param>
        public void ConfigureServices(IServiceCollection services)
        {
            this.version = "v" + Configuration.GetSection("version").Value;

            services.Configure<CookiePolicyOptions>(options =>
            {
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddDbContext<DataBaseContext>(options =>
               options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"))
                );

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddSingleton<Microsoft.AspNetCore.Mvc.Infrastructure.IActionContextAccessor, Microsoft.AspNetCore.Mvc.Infrastructure.ActionContextAccessor>();

            services.AddControllersWithViews();


            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc(this.version, new OpenApiInfo { Title = "API Model", Version = this.version.ToUpper() });
                c.IncludeXmlComments(string.Format(@"\bin\UI.xml", System.AppDomain.CurrentDomain.BaseDirectory));
            });

            services.AddOptions();
        }

        /// <summary>
        /// This method gets called by the runtime. Use this method to configure the HTTP request pipeline. 
        /// </summary>
        /// <param name="app">application builder</param>
        /// <param name="env">environment web host</param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(a =>
                   a.AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowAnyOrigin()
                );

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/" + this.version + "/swagger.json", "API Model " + this.version.ToUpper());
                c.DefaultModelsExpandDepth(-1);
            });

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();

                endpoints.MapControllerRoute(name: "default",
                  pattern: "api/{controller=Home}/{action=Index}/{id?}");
            });

            this.AutofacContainer = app.ApplicationServices.GetAutofacRoot();
        }


        // ConfigureContainer is where you can register things directly
        // with Autofac. This runs after ConfigureServices so the things
        // here will override registrations made in ConfigureServices.
        // Don't build the container; that gets done for you by the factory.
    
        /// <summary>
        /// 
        /// </summary>
        /// <param name="builder"></param>
        public void ConfigureContainer(ContainerBuilder builder)
        {
            // Register your own things directly with Autofac here. Don't
            // call builder.Populate(), that happens in AutofacServiceProviderFactory
            // for you.
            builder.RegisterModule(new ServiceModules());
        }
    }
}