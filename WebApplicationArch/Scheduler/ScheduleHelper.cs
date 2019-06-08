﻿using Hangfire;
using Marlabs.Tool.Business.Core.JobHelpers;

namespace WebApplicationArch.Scheduler
{
    public class ScheduleHelper
    {
        #region Initiation

        public static bool IsInitiated { get; private set; }

        public static void Initiate()
        {
            // Add/Update Recurring jobs
            
            RecurringJob.AddOrUpdate(SchedulingJobManager.PROCESS_NOTIFICATION_SENDING_JOB_NAME,
                                        () => new SchedulingJobManager().ProcessNotificationToDoctorAndAmbulance(), Cron.Minutely);
        
            IsInitiated = true;
        }

        #endregion

    }
}