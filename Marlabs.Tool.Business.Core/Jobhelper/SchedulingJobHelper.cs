using Marlabs.Tool.Data.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marlabs.Tool.Business.Core.JobHelpers
{
   public class SchedulingJobManager
    {

        private readonly UnitOfWork _unitOfWork;

        public SchedulingJobManager()
        {
        }

        public const string PROCESS_NOTIFICATION_SENDING_JOB_NAME = "Process-Notification-Sending-Job";

        public bool ProcessNotificationToDoctorAndAmbulance()
        {
            // this is the place where we have to send the notification to Dr and Ambulance 

           // get unnotified patient and 
               // 1. collect near By dr and Ambulance details 
               //2. create message or call notification and send them

            return true;
            }
            

        
        }

        
}
