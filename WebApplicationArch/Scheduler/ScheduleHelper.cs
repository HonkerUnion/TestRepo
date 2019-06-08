using Hangfire;
using Marlabs.Tool.Business.Core.JobHelpers;

namespace WebApplicationArch.Scheduler
{
   /// <summary>
   /// This is basaclly job which run every minute to check and notification is accepted by other autority , if yes then it send message back to patient to intimate it 
   /// </summary>
    public class ScheduleHelper
    {
        #region Initiation

        public static bool IsInitiated { get; private set; }

        public static void Initiate()
        {
            // Add/Update Recurring jobs
            
            RecurringJob.AddOrUpdate(SchedulingJobManager.PROCESS_NOTIFICATION_SENDING_JOB_NAME,
                                        () => new SchedulingJobManager().ProcessNotificationToDoctorAndAmbulanceForNotAcceptedUser(), Cron.Minutely);

            RecurringJob.AddOrUpdate(SchedulingJobManager.PROCESS_NOTIFICATION_SENDING_JOB_NAME,
                                        () => new SchedulingJobManager().ProcessNotificationToPatientAboutDoctorAndAmbulance(0), Cron.Minutely);

            IsInitiated = true;
        }

        #endregion

    }
}