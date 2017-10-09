using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Owin;
using System.Web.Http;

[assembly: OwinStartupAttribute(typeof(MinistriaEKthimit.Startup))]
namespace MinistriaEKthimit
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);

            HttpConfiguration config = new HttpConfiguration();

            // Web API routes
            config.MapHttpAttributeRoutes();

            app.UseCors(CorsOptions.AllowAll);

            app.UseWebApi(config);
        }
    }
}
