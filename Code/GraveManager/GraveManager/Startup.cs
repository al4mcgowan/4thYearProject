using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GraveManager.Startup))]
namespace GraveManager
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
