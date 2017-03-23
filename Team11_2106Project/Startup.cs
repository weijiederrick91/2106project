using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Team11_2106Project.Startup))]
namespace Team11_2106Project
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
