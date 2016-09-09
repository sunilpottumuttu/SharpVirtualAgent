using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SharpVirtualAgentUI.Startup))]
namespace SharpVirtualAgentUI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
