using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ClinicManagement.Startup))]
namespace ClinicManagement
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
