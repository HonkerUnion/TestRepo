using BusinessEntity;
using System.Collections.Generic;

namespace Marlabs.Tool.Business.Core
{
    /// <summary>
    /// Product Service Contract
    /// </summary>
    public interface IPushNotificationServices
    {
        bool updateNotoficationAlert(int userInformationId);
        bool updateAmulatoryConfirmStatus(int notificationId, int AmulatoryId);
        bool updatePhysicanInfoConfirmStatus(int notificationId, int physicanId);
        bool updateDrugCentreConfirmStatus(int notificationId, int DrugCentreId);
        bool updateProviderConfirmStatus(int notificationId, string ProviderId);
        bool updateCasemanagerConfirmStatus(int notificationId, int CaseManagerId);
    }
}
