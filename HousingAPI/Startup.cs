using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(HousingAPI.Startup))]

namespace HousingAPI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);

            
        }
        
    }
}
