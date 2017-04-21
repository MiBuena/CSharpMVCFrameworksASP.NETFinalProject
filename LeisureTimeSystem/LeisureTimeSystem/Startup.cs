using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LeisureTimeSystem.Startup))]
namespace LeisureTimeSystem
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
