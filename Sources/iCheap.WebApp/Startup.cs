using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(iCheap.WebApp.Startup))]
namespace iCheap.WebApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
