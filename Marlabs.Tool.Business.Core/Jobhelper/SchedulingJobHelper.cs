using BusinessServices;
using Marlabs.Tool.Data.UnitOfWork;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Marlabs.Tool.Business.Core.JobHelpers
{
   public class SchedulingJobManager
    {

        private readonly UnitOfWork _unitOfWork;
        private readonly IPushNotificationServices _pushNotificationServices;
      
        private readonly string baseAddess = "localhost:51926/";

        public SchedulingJobManager()
        {
            _pushNotificationServices = new PushNotificationServices();
        }

        public const string PROCESS_NOTIFICATION_SENDING_JOB_NAME = "Process-Notification-Sending-Job";

        public bool ProcessNotificationToDoctorAndAmbulance(int userInfoId)
        {

            if (userInfoId > 0)
                _pushNotificationServices.updateNotoficationAlert(userInfoId);

            List<NotificationWithMessageBody> notificationToBeSentList = new List<NotificationWithMessageBody>();


            // Assumeing all the ambulance , doctor and provider (hospital) would be near by (filtered using LATITUDE and LONGITUDE)
            var notificationId = _unitOfWork.PushNotificationRepository.GetFirst(y => y.USERINFORMATIONID == userInfoId);

            if (notificationId.AMBULATORYCONFIRMSTATUS == "N")
            {
                var getNotificationDetailsForAmbulance = _unitOfWork.AmbulanceServiceRepository.GetAll().Take(3);
                foreach (var ambulance in getNotificationDetailsForAmbulance)
                {
                    NotificationWithMessageBody notContent = new NotificationWithMessageBody();
                    notContent.MobileNumber = ambulance.AMBULATORYTELEPHONE;
                    notContent.MessageBody = string.Format("Dear Ambulance,Please Accept the request of patient Emergency Hospitalization,His location is \"https://goo.gl/maps/gzNMmTaAyM5rNZUS6\" + Click" + baseAddess + notificationId + "/Ambulance" + "/" + ambulance.AMBULATORYID + " to Accept It");
                    notificationToBeSentList.Add(notContent);
                }
            }
            if (notificationId.PHYSICIANCONFIRMSTATUS == "N")
            {
                var getNotificationDetailsForDoctor = _unitOfWork.PhysicanInfoRepository.GetManyQueryable(y => y.TREATMENTTYPESPECIALIST == "3").Take(3);
                foreach (var doctor in getNotificationDetailsForDoctor)
                {
                    NotificationWithMessageBody notContent = new NotificationWithMessageBody();
                    notContent.MobileNumber = doctor.TELEPHONE;
                    notContent.MessageBody = string.Format("Dear Doctor,Please Accept the request of patient Emergency Hospitalization,His location is \"https://goo.gl/maps/gzNMmTaAyM5rNZUS6\" + Click" + baseAddess + notificationId + "/Ambulance" + "/" + doctor.PHYSICIANID + " to Accept It");
                    notificationToBeSentList.Add(notContent);
                }
            }

            if (notificationId.PROVIDERCONFIRMSTATUS == "N")
            {
                var getNotificationDetailsForProvider = _unitOfWork.ProviderInfoRepository.GetManyQueryable(y => y.SPECIALISTTYPE == "3").Take(3);
                foreach (var hospital in getNotificationDetailsForProvider)
                {
                    NotificationWithMessageBody notContent = new NotificationWithMessageBody();
                    notContent.MobileNumber = hospital.TELEPHONE;
                    notContent.MessageBody = string.Format("Dear Hospital Provider,Please Accept the request of patient Emergency Hospitalization,His location is \"https://goo.gl/maps/gzNMmTaAyM5rNZUS6\" + Click" + baseAddess + notificationId + "/Ambulance" + "/" + hospital.PROVIDERNO + " to Accept It");
                    notificationToBeSentList.Add(notContent);
                }
            }

            if (notificationId.PROVIDERCONFIRMSTATUS == "N")
            {
                var getNotificationDetailsForDrugCentre = _unitOfWork.DrugCentreRepository.GetAll().Take(3);


                foreach (var drugCenter in getNotificationDetailsForDrugCentre)
                {
                    NotificationWithMessageBody notContent = new NotificationWithMessageBody();
                    notContent.MobileNumber = drugCenter.DRUGCENTRECONTACTNO;
                    notContent.MessageBody = string.Format("Dear Drug Center,For Case Id {0},Please check the patient History and drug Details and keep it ready.Also Connect to Doctor for Case.", userInfoId);
                    notificationToBeSentList.Add(notContent);
                }
            }


          foreach(var notificationToSent in notificationToBeSentList)
            {
                SendMessage(notificationToSent.MobileNumber, notificationToSent.MessageBody);
            }

           
            // this is the place where we have to send the notification to Dr and Ambulance 

            // get unnotified patient and 
            // 1. collect near By dr and Ambulance details 
            //2. create message or call notification and send them

            return true;
            }

        public string createMessageBody()
        {
            return null;
        }

        public bool ProcessNotificationToPatientAboutDoctorAndAmbulance(int userId =0)
        {
            var notificationInfo = _unitOfWork.PushNotificationRepository.GetManyQueryable(y => y.USERINFORMATIONID == userId).FirstOrDefault();
            var userDetails = _unitOfWork.UserInformationRepository.GetByID(userId);
            var notificationToBeSentList = new List<NotificationWithMessageBody>();
            if (notificationInfo != null && notificationInfo.AMBULATORYCONFIRMSTATUS == "Y")
            {
                var ambulanceDetails = _unitOfWork.AmbulanceServiceRepository.GetFirst(y => y.AMBULATORYID == notificationInfo.AMBULATORYID);
                NotificationWithMessageBody notContent = new NotificationWithMessageBody();
                notContent.MobileNumber = userDetails.PRIMARYCONTACTNO;
                notContent.MessageBody = string.Format("Dear Patient,Please find ambulance Live Location and his Number,His location is \"https://goo.gl/maps/gzNMmTaAyM5rNZUS6\" + Number"+ambulanceDetails.AMBULATORYTELEPHONE);
                notificationToBeSentList.Add(notContent);
            }
            if (notificationInfo != null && notificationInfo.PHYSICIANCONFIRMSTATUS == "Y")
            {
                var physician = _unitOfWork.PhysicanInfoRepository.GetFirst(y => y.PHYSICIANID == notificationInfo.PHYSICIANID);
                NotificationWithMessageBody notContent = new NotificationWithMessageBody();
                notContent.MobileNumber = userDetails.PRIMARYCONTACTNO;
                notContent.MessageBody = string.Format("Dear Patient,Please find ambulance Live Location and his Number,His location is \"https://goo.gl/maps/gzNMmTaAyM5rNZUS6\" + Number" + physician.TELEPHONE);
                notificationToBeSentList.Add(notContent);
            }

            foreach (var notificationToSent in notificationToBeSentList)
            {
                SendMessage(notificationToSent.MobileNumber, notificationToSent.MessageBody);
            }


            return true;
        }


        public bool SendMessage(string number="8087469854",string messagebody= "test Honker Union")
        {
                string result;
            string countycode = "91"; // TODO:: take it from config file 
            number = countycode + number;
            bool retValue = false;
                string apiKey = "BarVHzMYZjY-QOhnLqHz8eJOxLdbBNlQLYkWcCNzmQ";
                string numbers = number; // in a comma seperated list
            string message = messagebody;
                //string Send = "honker union";

                String url = "https://api.txtlocal.com/send/?apikey=" + apiKey + "&numbers=" + numbers + "&message=" + message +"&sender=Honker Union";
                //refer to parameters to complete correct url string

                StreamWriter myWriter = null;
                HttpWebRequest objRequest = (HttpWebRequest)WebRequest.Create(url);

                objRequest.Method = "POST";
                objRequest.ContentLength = Encoding.UTF8.GetByteCount(url);
                objRequest.ContentType = "application/x-www-form-urlencoded";
                try
                {
                    myWriter = new StreamWriter(objRequest.GetRequestStream());
                    myWriter.Write(url);
                retValue = true;
                }
                catch (Exception ex)
                {
                //return ex.Message;
                throw;
                }
                finally
                {
                    myWriter.Close();
                }

                HttpWebResponse objResponse = (HttpWebResponse)objRequest.GetResponse();
                using (StreamReader sr = new StreamReader(objResponse.GetResponseStream()))
                {
                    result = sr.ReadToEnd();
                    // Close and clean up the StreamReader
                    sr.Close();
                }
            return retValue;
                //return result;
               // MessageBox.Show(result);
            }

        public class NotificationWithMessageBody
        {
            public string MobileNumber;
            public string MessageBody;
        }
        }    
        }
