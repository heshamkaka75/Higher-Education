using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MOHEv2.Startup))]
namespace MOHEv2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
