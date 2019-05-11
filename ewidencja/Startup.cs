using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ewidencja.Startup))]
namespace ewidencja
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
