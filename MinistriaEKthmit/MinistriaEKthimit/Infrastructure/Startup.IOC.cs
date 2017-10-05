using Microsoft.Practices.Unity;
using MinistriaEKthimit.Controllers;
using MinistriaEKthimit.Services.Contract;
using MinistriaEKthimit.Services.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MinistriaEKthimit.Infrastructure
{
    public static class Startup
    {

        #region Configuration
        public static void ConfigureContainer()
        {
            IUnityContainer unityContainer = new UnityContainer();
            RegisterServices(unityContainer);

            DependencyResolver.SetResolver(new UnityResolver(unityContainer));

        }
        #endregion

        private static void RegisterServices(IUnityContainer container)
        {
            //Here you have to register Interfaces with corresponding Concrete Types
            //How to do:
            //----------------------------------------------------------------------
            // ------->     container.RegisterType<ITest, ConcreteTest>();    <-----
            //----------------------------------------------------------------------


            //Models




            //Services
            container.RegisterType<IPersonService, PersonService>();



            //Repository





            //Others
            container.RegisterType<ITest, test>();

        }


        #region Resolver

        private class UnityResolver : IDependencyResolver
        {
            private IUnityContainer unityContainer;

            public UnityResolver(IUnityContainer unityContainer)
            {
                this.unityContainer = unityContainer;
            }

            public object GetService(Type serviceType)
            {
                try
                {
                    return unityContainer.Resolve(serviceType);
                }
                catch (Exception)
                {

                    return null;
                }
            }

            public IEnumerable<object> GetServices(Type serviceType)
            {
                try
                {
                    return unityContainer.ResolveAll(serviceType);
                }
                catch (Exception)
                {

                    return new List<object>();
                }
            }

            #endregion
        }
    }
}