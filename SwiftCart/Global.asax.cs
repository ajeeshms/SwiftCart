using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.Http;
using AutoMapper;
using SwiftCart.Models.Profiles;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Extensions.DependencyInjection;
using SwiftCart.Data.Repository;

namespace SwiftCart
{
    public class Global : HttpApplication
    {
        public static IMapper MapperInstance { get; private set; }
        public static IServiceProvider ServiceProvider { get; private set; }

        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            // 🔹 Initialize Enterprise Library Database Factory
            DatabaseProviderFactory factory = new DatabaseProviderFactory();
            DatabaseFactory.SetDatabaseProviderFactory(factory);

            var mapperConfig = new MapperConfiguration(cfg => {
                cfg.AddProfile<ProductProfile>();
                cfg.AddProfile<CartItemProfile>();
            });
            MapperInstance = mapperConfig.CreateMapper(); // Store globally

            var services = new ServiceCollection();

            // Register repositories and services
            services.AddSingleton<IProductRepository, ProductRepository>();

            // Build ServiceProvider
            ServiceProvider = services.BuildServiceProvider();
        }
    }
}