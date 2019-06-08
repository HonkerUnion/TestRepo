using BusinessEntity;
using System.Collections.Generic;

namespace Marlabs.Tool.Business.Core
{
    /// <summary>
    /// Product Service Contract
    /// </summary>
    public interface IPushNotificationServices
    {
        void updateNotoficationAlert(int userInformationId);
    }
}
