using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TeamManagement.Startup))]
namespace TeamManagement
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
