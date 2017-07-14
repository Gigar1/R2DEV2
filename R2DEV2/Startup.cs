using Microsoft.Owin;
using Owin;
using R2DEV2.Data;
using System.Web.Services.Description;

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

    public void ConfigureServices(ServiceCollection services)
    {
        // Add framework services.
        services.AddDbContext<LexiconContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

        services.AddMvc();
    }
}
