using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using System.Web.Security;
using System.Web;

namespace GradApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
