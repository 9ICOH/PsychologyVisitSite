
using Microsoft.Owin;

[assembly: OwinStartup(typeof(PsychologyVisitSite.WebUI.Startup))]


namespace PsychologyVisitSite.WebUI
{
    using Owin;

    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}