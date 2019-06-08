using System;
using Hangfire.Common;
using Hangfire.States;
using Hangfire.Storage;

namespace WebApplicationArch.Scheduler
{
    /// <summary>
    /// Ref: https://discuss.hangfire.io/t/how-to-configure-the-retention-time-of-job/34/7
    /// </summary>
    public class ProlongExpirationTimeAttribute : JobFilterAttribute, IApplyStateFilter
    {
        public void OnStateUnapplied(ApplyStateContext context, IWriteOnlyTransaction transaction)
        {
            context.JobExpirationTimeout = TimeSpan.FromDays(1);
        }

        public void OnStateApplied(ApplyStateContext context, IWriteOnlyTransaction transaction)
        {
            context.JobExpirationTimeout = TimeSpan.FromDays(1);
        }
    }
}