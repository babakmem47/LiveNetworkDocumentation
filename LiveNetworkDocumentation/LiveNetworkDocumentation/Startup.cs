using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LiveNetworkDocumentation.Startup))]
namespace LiveNetworkDocumentation
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
