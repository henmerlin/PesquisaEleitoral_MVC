using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PesquisaEleitoral_MVC.Startup))]
namespace PesquisaEleitoral_MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
