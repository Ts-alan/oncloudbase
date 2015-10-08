using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(oncloud.Web.oddBase.Startup))]
namespace oncloud.Web.oddBase
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
