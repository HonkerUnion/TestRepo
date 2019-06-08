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
        /// Insert NotoficationAlert by userInformationId
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        public bool updateNotoficationAlert(int userInformationId)
        {
            var success = false;
            var userInfomations = _unitOfWork.UserInformationRepository.GetAll().ToList().Where(u => u.USERINFORMATIONID == userInformationId).FirstOrDefault();

            if (userInfomations != null)
            {
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
                        TREATMENTTYPE = userInfomations.TREATMENTTYPE 
                    };
                    _unitOfWork.PushNotificationRepository.Insert(pushNotification);
                    _unitOfWork.Save();
                    scope.Complete();
                    success = true;
                }
            }
            return success;
        }

        /// <summary>
        /// Update Amulatory
        /// </summary>
        /// <param name="notificationId"></param>
        /// <param name="AmulatoryId"></param>
        /// <returns></returns>
        public bool updateAmulatoryConfirmStatus(int notificationId,int AmulatoryId)
        {
            var success = false;
            using (var scope = new TransactionScope())
            {
                var pushNotification = _unitOfWork.PushNotificationRepository.GetAll().ToList().Where(u => u.NOTIFICATIONID == notificationId).FirstOrDefault();
                if (pushNotification != null)
                {
                    pushNotification.AMBULATORYCONFIRMSTATUS = "Y";
                    pushNotification.AMBULATORYID = AmulatoryId;
                    pushNotification.UPDATEDON = System.DateTime.UtcNow;
                    _unitOfWork.PushNotificationRepository.Update(pushNotification);
                    _unitOfWork.Save();
                    scope.Complete();
                    success = true;
                }
            }
            return success;
        }


        /// <summary>
        /// Update Amulatory
        /// </summary>
        /// <param name="notificationId"></param>
        /// <param name="physicanId"></param>
        /// <returns></returns>
        public bool updatePhysicanInfoConfirmStatus(int notificationId, int physicanId)
        {
            var success = false;
            using (var scope = new TransactionScope())
            {
                var pushNotification = _unitOfWork.PushNotificationRepository.GetAll().ToList().Where(u => u.NOTIFICATIONID == notificationId).FirstOrDefault();
                if (pushNotification != null)
                {
                    pushNotification.PHYSICIANCONFIRMSTATUS = "Y";
                    pushNotification.PHYSICIANID = physicanId;
                    pushNotification.UPDATEDON = System.DateTime.UtcNow;
                    _unitOfWork.PushNotificationRepository.Update(pushNotification);
                    _unitOfWork.Save();
                    scope.Complete();
                    success = true;
                }
            }
            return success;
        }


        /// <summary>
        /// Update Amulatory
        /// </summary>
        /// <param name="notificationId"></param>
        /// <param name="DrugCentreId"></param>
        /// <returns></returns>
        public bool updateDrugCentreConfirmStatus(int notificationId, int DrugCentreId)
        {
            var success = false;
            using (var scope = new TransactionScope())
            {
                var pushNotification = _unitOfWork.PushNotificationRepository.GetAll().ToList().Where(u => u.NOTIFICATIONID == notificationId).FirstOrDefault();
                if (pushNotification != null)
                {
                    pushNotification.DRUGCENTRECONFIRMSTATUS = "Y";
                    pushNotification.DRUGCENTREID = DrugCentreId;
                    pushNotification.UPDATEDON = System.DateTime.UtcNow;
                    _unitOfWork.PushNotificationRepository.Update(pushNotification);
                    _unitOfWork.Save();
                    scope.Complete();
                    success = true;
                }
            }
            return success;
        }


        /// <summary>
        /// Update Amulatory
        /// </summary>
        /// <param name="notificationId"></param>
        /// <param name="ProviderId"></param>
        /// <returns></returns>
        public bool updateProviderConfirmStatus(int notificationId, string ProviderId)
        {
            var success = false;
            using (var scope = new TransactionScope())
            {
                var pushNotification = _unitOfWork.PushNotificationRepository.GetAll().ToList().Where(u => u.NOTIFICATIONID == notificationId).FirstOrDefault();
                if (pushNotification != null)
                {
                    pushNotification.PROVIDERCONFIRMSTATUS = "Y";
                    pushNotification.PROVIDERNO = ProviderId;
                    pushNotification.UPDATEDON = System.DateTime.UtcNow;
                    _unitOfWork.PushNotificationRepository.Update(pushNotification);
                    _unitOfWork.Save();
                    scope.Complete();
                    success = true;
                }
            }
            return success;
        }

        /// <summary>
        /// Update Amulatory
        /// </summary>
        /// <param name="notificationId"></param>
        /// <param name="AmulatoryId"></param>
        /// <returns></returns>
        public bool updateCasemanagerConfirmStatus(int notificationId, int CaseManagerId)
        {
            var success = false;
            using (var scope = new TransactionScope())
            {
                var pushNotification = _unitOfWork.PushNotificationRepository.GetAll().ToList().Where(u => u.NOTIFICATIONID == notificationId).FirstOrDefault();
                if (pushNotification != null)
                {
                    pushNotification.CASEMANAGERCONFIRMSTATUS = "Y";
                    pushNotification.CASEMANAGERID = CaseManagerId;
                    pushNotification.UPDATEDON = System.DateTime.UtcNow;
                    _unitOfWork.PushNotificationRepository.Update(pushNotification);
                    _unitOfWork.Save();
                    scope.Complete();
                    success = true;
                }
            }
            return success;
        }


    }
}
