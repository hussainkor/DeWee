using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DeWee.Startup))]
namespace DeWee
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
