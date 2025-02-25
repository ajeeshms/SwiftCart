using AutoMapper;
using SwiftCart.Models.Profiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace SwiftCart.Api {
    public class Global : HttpApplication {

        public static IMapper MapperInstance { get; private set; }
        void Application_Start(object sender, EventArgs e) {
            // Code that runs on application startup
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            var mapperConfig = new MapperConfiguration(cfg => {
                cfg.AddProfile<ProductProfile>();
                cfg.AddProfile<CartItemProfile>();
            });
            MapperInstance = mapperConfig.CreateMapper(); // Store globally
        }
    }
}