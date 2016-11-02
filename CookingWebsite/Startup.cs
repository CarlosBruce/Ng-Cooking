using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CookingWebsite.Startup))]
namespace CookingWebsite
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
