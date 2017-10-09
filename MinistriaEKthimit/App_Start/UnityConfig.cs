using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Practices.Unity;
using MinistriaEKthimit.Controllers;
using MinistriaEKthimit.Models;
using System.Data.Entity;
using System.Web.Http;
using Unity.WebApi;


namespace MinistriaEKthimit
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            RegisterTypes(container);

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }



        public static void RegisterTypes(IUnityContainer container)
        {
            #region Authentification Injection
            container.RegisterType<DbContext, ApplicationDbContext>(new HierarchicalLifetimeManager());
            container.RegisterType<UserManager<ApplicationUser>>(new HierarchicalLifetimeManager());
            container.RegisterType<IUserStore<ApplicationUser>, UserStore<ApplicationUser>>(new HierarchicalLifetimeManager());
            container.RegisterType<AccountController>(new InjectionConstructor());
            #endregion  

            container.RegisterType<ITest, Test>();


        }


        public interface ITest
        {

        }
        public class Test : ITest
        {

        }
    }
}