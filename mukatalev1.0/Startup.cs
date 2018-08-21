using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(mukatalev1._0.Startup))]
namespace mukatalev1._0
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
