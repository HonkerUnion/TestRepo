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

        private readonly string baseAddess = "localhost:51926/";

        public SchedulingJobManager()
        {
        }

        public const string PROCESS_NOTIFICATION_SENDING_JOB_NAME = "Process-Notification-Sending-Job";

        public bool ProcessNotificationToDoctorAndAmbulance()
        {

            createMessageBody();

            SendMessage();
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

        public bool ProcessNotificationToPatientAboutDoctorAndAmbulance()
        {
            // var userInfomations = _unitOfWork.PushNotificationRepository.GetManyQueryable(y => y.
            //if (userInfomations != null)
            //{
            //    // share the live location of them 

            //}
            return false;
        }


        public bool SendMessage(string number="9663827431",string messagebody= "test Honker Union")
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
        }    
        }
