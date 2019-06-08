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
    }
}
