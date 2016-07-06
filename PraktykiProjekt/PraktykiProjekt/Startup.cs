using Microsoft.Owin;
using Owin;
using PraktykiProjekt.Quartz;

[assembly: OwinStartupAttribute(typeof(PraktykiProjekt.Startup))]
namespace PraktykiProjekt
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            JobScheduler.Start();
            ConfigureAuth(app);
        }
    }
}
