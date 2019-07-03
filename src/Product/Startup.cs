using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Routing;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Product.Interface;
using Product.Service;
using Product.Controllers;

namespace Product
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("product_appsettings.json", optional: true, reloadOnChange: true);

            builder.AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }
        
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddMvc();

            //create Autofac container build
            var builder = new ContainerBuilder();

            //populate the container with services here
            builder.RegisterType<ProductRepository>().As<IProductRepository>();

            builder.Populate(services);

            //build container
            var container = builder.Build();

            //return service provider
            return container.Resolve<IServiceProvider>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }

        //private void ConfigureRoute(IRouteBuilder routeBuilder)
        //{
        //    routeBuilder.MapRoute("Default", "{controller=Values}/{action=GetAllProducts}/{id?}");
        //}
    }
}
