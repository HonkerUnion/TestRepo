using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using BusinessEntity;
using Marlabs.Tool.Data;
using Marlabs.Tool.Business.Core;
using Marlabs.Tool.Data.UnitOfWork;
using System.Transactions;

namespace BusinessServices
{
    /// <summary>
    /// Offers services for product specific CRUD operations
    /// </summary>
    public class PushNotificationServices : IPushNotificationServices
    {
        private readonly UnitOfWork _unitOfWork;

        /// <summary>
        /// Public constructor.
        /// </summary>
        public PushNotificationServices()
        {
            _unitOfWork = new UnitOfWork();
        }

        /// <summary>
        /// Fetches userinformation by userId
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        public bool updateNotoficationAlert(int userInformationId)
        {
            var userInfomations = _unitOfWork.UserInformationRepository.GetAll().ToList().Where(u => u.USERINFORMATIONID == userInformationId).FirstOrDefault();
            using (var scope = new TransactionScope())
            {
                var pushNotification = new PUSHNOTIFICATION
                {
                    USERINFORMATIONID = userInfomations.USERINFORMATIONID,
                    USERID = userInfomations.USERID,
                    AMBULATORYCONFIRMSTATUS = "N",
                    CASEMANAGERCONFIRMSTATUS = "N",
                    DRUGCENTRECONFIRMSTATUS = "N",
                    PHYSICIANCONFIRMSTATUS = "N",
                    PROVIDERCONFIRMSTATUS = "N",
                    CREATEDON = System.DateTime.UtcNow,
                };
                //_unitOfWork.ProductRepository.Insert(product);
                //_unitOfWork.Save();
                //scope.Complete();
                //return product.ProductId;
            }
            return true;
        }
    }
}
