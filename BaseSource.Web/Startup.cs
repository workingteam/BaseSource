using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BaseSource.Web.Startup))]
namespace BaseSource.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
