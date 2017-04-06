using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(StudentProjectManagementAuth.Startup))]
namespace StudentProjectManagementAuth
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
