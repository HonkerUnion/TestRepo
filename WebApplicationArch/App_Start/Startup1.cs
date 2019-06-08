using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using WebApplicationArch.Scheduler;
using System.Web;

[assembly: OwinStartup(typeof(WebApplicationArch.App_Start.Startup))]

namespace WebApplicationArch.App_Start
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            HangfireBootstrapper.Instance.Start();
            BackgroundScheduledProcessorConfig.InitiateProcessor(app,HttpContext.Current);
            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=316888
        }
    }
}
