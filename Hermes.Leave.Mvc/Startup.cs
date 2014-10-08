using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Hermes.Leave.Mvc.Startup))]
namespace Hermes.Leave.Mvc
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
