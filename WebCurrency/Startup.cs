using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebCurrency.Startup))]
namespace WebCurrency
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
