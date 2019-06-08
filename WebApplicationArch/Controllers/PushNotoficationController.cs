using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BusinessEntity;
using BusinessServices;
using Marlabs.Tool.Business.Core;

namespace WebApplicationArch.Controllers
{
    [RoutePrefix("Notification")]
    public class PushNotoficationController : ApiController
    {

        private readonly IUserInfoServices _userInfoServices;

        #region Public Constructor

        /// <summary>
        /// Public constructor to initialize user service instance
        /// </summary>
        public PushNotoficationController()
        {
            _userInfoServices = new UserInformationServices();
        }

        #endregion

        [HttpPost]
        [Route("Alert")]
        public HttpResponseMessage UpdateNotoficationAlert(int userInformationId)
        {
            var userInformationList = _userInfoServices.getUserInformationByUserId(userInformationId);
            if (userInformationList != null)
                return Request.CreateResponse(HttpStatusCode.OK, userInformationList);
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No userinformation List Available");
        }
    }
}
