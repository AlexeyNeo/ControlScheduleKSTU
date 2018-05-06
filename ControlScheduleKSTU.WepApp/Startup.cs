using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ControlScheduleKSTU.WepApp.Startup))]
namespace ControlScheduleKSTU.WepApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
