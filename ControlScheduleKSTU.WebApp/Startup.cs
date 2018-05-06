using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ControlScheduleKSTU.WebApp.Startup))]
namespace ControlScheduleKSTU.WebApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
