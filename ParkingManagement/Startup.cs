using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ParkingManagement.Startup))]
namespace ParkingManagement
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
