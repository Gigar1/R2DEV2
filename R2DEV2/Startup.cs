using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(R2DEV2.Startup))]
namespace R2DEV2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
