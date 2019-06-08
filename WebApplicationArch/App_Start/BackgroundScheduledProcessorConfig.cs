using System.Web;
using Hangfire;
using Owin;
using WebApplicationArch.Scheduler;

namespace WebApplicationArch
{
    public class BackgroundScheduledProcessorConfig
    {
        public const string HANGFIRE_DB_CONN_STR_NAME = "Hangfire.UexDb";
        public const string HANGFIRE_DB_SCHEMA_NAME = "hangfire-uex-db";

        public static void InitiateProcessor(IAppBuilder app, HttpContext httpContext)
        {
            #region Hangfire (For Background job processing)

            app.UseHangfireDashboard();
            app.UseHangfireServer();

            // Initiate the application scheduler i.e. link to get into Hangfire
            ScheduleHelper.Initiate();

            #endregion
        }


    }
}