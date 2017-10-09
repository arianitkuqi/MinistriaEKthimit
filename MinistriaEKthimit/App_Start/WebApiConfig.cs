using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.WebApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using static MinistriaEKthimit.UnityConfig;

namespace MinistriaEKthimit
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            var container = new UnityContainer();

            container.RegisterType<ITest, Test>();

            config.DependencyResolver = new UnityDependencyResolver(container);


            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
