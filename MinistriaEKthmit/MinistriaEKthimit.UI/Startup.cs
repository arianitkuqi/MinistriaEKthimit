using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MinistriaEKthimit.UI.Startup))]
namespace MinistriaEKthimit.UI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
