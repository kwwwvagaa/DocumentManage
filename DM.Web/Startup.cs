using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DM.Web.Startup))]
namespace DM.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
