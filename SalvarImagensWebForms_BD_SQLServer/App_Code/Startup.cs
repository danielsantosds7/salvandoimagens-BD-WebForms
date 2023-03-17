using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SalvarImagensWebForms_BD_SQLServer.Startup))]
namespace SalvarImagensWebForms_BD_SQLServer
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
