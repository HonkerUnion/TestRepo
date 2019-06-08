namespace WebApplicationArch.Controllers
{
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;
    using BusinessServices;
    using Marlabs.Tool.Business.Core;

    [RoutePrefix("Notification")]
    public class PushNotoficationController : ApiController
    {

        private readonly IPushNotificationServices _pushNotificationServices;

        #region Public Constructor

        /// <summary>
        /// Public constructor to initialize user service instance
        /// </summary>
        public PushNotoficationController()
        {
            _pushNotificationServices = new PushNotificationServices();
        }

        #endregion

        [HttpPost]
        [Route("Alert")]
        public HttpResponseMessage UpdateNotoficationAlert(int userInformationId)
        {
            var result = _pushNotificationServices.updateNotoficationAlert(userInformationId);
            if (result)
                return Request.CreateResponse(HttpStatusCode.OK, result);
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No Notification Available");
        }

        [HttpPost]
        [Route("{notificationId}/Ambulance/{AmulatoryId}")]
        public HttpResponseMessage updateAmulatoryConfirmStatus(int notificationId, int AmulatoryId)
        {
            var result = _pushNotificationServices.updateAmulatoryConfirmStatus(notificationId, AmulatoryId);
            if (result)
                return Request.CreateResponse(HttpStatusCode.OK, result);
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No Notification Available");
        }

        [HttpPost]
        [Route("{notificationId}/Ambulance/{physicanId}")]
        public HttpResponseMessage updatePhysicanInfoConfirmStatus(int notificationId, int physicanId)
        {
            var result = _pushNotificationServices.updatePhysicanInfoConfirmStatus(notificationId, physicanId);
            if (result)
                return Request.CreateResponse(HttpStatusCode.OK, result);
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No Notification Available");
        }

        [HttpPost]
        [Route("{notificationId}/Ambulance/{DrugCentreId}")]
        public HttpResponseMessage updateDrugCentreConfirmStatus(int notificationId, int DrugCentreId)
        {
            var result = _pushNotificationServices.updateDrugCentreConfirmStatus(notificationId, DrugCentreId);
            if (result)
                return Request.CreateResponse(HttpStatusCode.OK, result);
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No Notification Available");
        }


        [HttpPost]
        [Route("{notificationId}/Ambulance/{ProviderId}")]
        public HttpResponseMessage updateProviderConfirmStatus(int notificationId, string ProviderId)
        {
            var result = _pushNotificationServices.updateProviderConfirmStatus(notificationId, ProviderId);
            if (result)
                return Request.CreateResponse(HttpStatusCode.OK, result);
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No Notification Available");
        }

        [HttpPost]
        [Route("{notificationId}/Ambulance/{CaseManagerId}")]
        public HttpResponseMessage updateCasemanagerConfirmStatus(int notificationId, int CaseManagerId)
        {
            var result = _pushNotificationServices.updateCasemanagerConfirmStatus(notificationId, CaseManagerId);
            if (result)
                return Request.CreateResponse(HttpStatusCode.OK, result);
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No Notification Available");
        }
    }
}
