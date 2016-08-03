using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(KapyNews2.Startup))]
namespace KapyNews2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
