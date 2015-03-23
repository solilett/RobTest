using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(webServices.Startup))]
namespace webServices
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
