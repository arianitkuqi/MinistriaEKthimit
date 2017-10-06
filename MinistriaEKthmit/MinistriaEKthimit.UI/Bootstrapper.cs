using System.Web.Mvc;
using Microsoft.Practices.Unity;
using Unity.Mvc4;
using MinistriaEKthimit.Services.Contract;
using MinistriaEKthimit.Services.Fake;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using MinistriaEKthimit.UI.Controllers;
using System.Data.Entity;
using MinistriaEKthimit.UI.Models;

namespace MinistriaEKthimit.UI
{
    public static class Bootstrapper
    {
        public static IUnityContainer Initialise()
        {
            var container = BuildUnityContainer();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));

            return container;
        }

        private static IUnityContainer BuildUnityContainer()
        {
            var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();    
            RegisterTypes(container);

            return container;
        }

        public static void RegisterTypes(IUnityContainer container)
        {

            #region Authentification Injection
            container.RegisterType<DbContext, ApplicationDbContext>(new HierarchicalLifetimeManager());
            container.RegisterType<UserManager<ApplicationUser>>(new HierarchicalLifetimeManager());
            container.RegisterType<IUserStore<ApplicationUser>, UserStore<ApplicationUser>>(new HierarchicalLifetimeManager());
            container.RegisterType<AccountController>(new InjectionConstructor());
            #endregion


            //Service Injection
            container.RegisterType<ICityService, FakeCityService>();
        }
    }
}