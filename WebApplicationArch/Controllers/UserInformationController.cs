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
    [RoutePrefix("UserInfo")]
    public class UserInformationController : ApiController
    {

        private readonly IUserInfoServices _userInfoServices;

        #region Public Constructor

        /// <summary>
        /// Public constructor to initialize user service instance
        /// </summary>
        public UserInformationController()
        {
            _userInfoServices = new UserInformationServices();
        }

        #endregion

        /// <summary>
        /// THis method will Get the List Of User 
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{userId}")]
        public HttpResponseMessage Get(int userId)
        {
            var userInformationList = _userInfoServices.getUserInformationByUserId(userId);
            if (userInformationList != null)
                return Request.CreateResponse(HttpStatusCode.OK, userInformationList);
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No userinformation List Available");
        }

        /// <summary>
        /// This will Save the user in case of Emergecy Request , this is the main methon which take the information from patient and about their condition and intimate the same to other autherity 
        /// </summary>
        /// <param name="userInfo"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("{save}")]
        public HttpResponseMessage post(UserInformation userInfo)
        {
             _userInfoServices.SaveUserInformationByUserId(userInfo);
                return Request.CreateResponse(HttpStatusCode.OK, userInfo);
           
        }

    }
}
