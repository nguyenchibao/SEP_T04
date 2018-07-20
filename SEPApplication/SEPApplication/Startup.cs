using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SEPApplication.Startup))]
namespace SEPApplication
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
