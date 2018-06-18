using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Stromatolite.Startup))]
namespace Stromatolite
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
