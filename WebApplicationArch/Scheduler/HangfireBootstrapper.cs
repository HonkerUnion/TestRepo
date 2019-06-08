using System;
using System.Web.Hosting;
using Hangfire;
using Hangfire.SqlServer;

namespace WebApplicationArch.Scheduler
{
    public class HangfireBootstrapper : IRegisteredObject
    {
        public static readonly HangfireBootstrapper Instance = new HangfireBootstrapper();

        private readonly object _lockObject = new object();
        private bool _started = false;

        private BackgroundJobServer _backgroundJobServer;

        private HangfireBootstrapper()
        {
        }

        public void Start()
        {
            lock (_lockObject)
            {
                if (_started) return;
                _started = true;

                HostingEnvironment.RegisterObject(this);

                var ssso = new SqlServerStorageOptions { CommandTimeout = TimeSpan.FromMinutes(10), SchemaName = BackgroundScheduledProcessorConfig.HANGFIRE_DB_SCHEMA_NAME };
                GlobalConfiguration.Configuration.UseSqlServerStorage(BackgroundScheduledProcessorConfig.HANGFIRE_DB_CONN_STR_NAME, ssso);

                GlobalJobFilters.Filters.Add(new ProlongExpirationTimeAttribute());

                _backgroundJobServer = new BackgroundJobServer();
            }
        }

        public void Stop()
        {
            lock (_lockObject)
            {
                if (_backgroundJobServer != null)
                {
                    _backgroundJobServer.Dispose();
                    _backgroundJobServer = null;
                }

                HostingEnvironment.UnregisterObject(this);
            }
        }

        void IRegisteredObject.Stop(bool immediate)
        {
            Stop();
        }

        ~HangfireBootstrapper()
        {
            Stop();
        }
    }
}