using BusinessEntity;
using System.Collections.Generic;

namespace Marlabs.Tool.Business.Core
{
    /// <summary>
    /// Product Service Contract
    /// </summary>
    public interface IUserInfoServices
    {
        List<UserInformation> getUserInformationByUserId(int userId);
        void SaveUserInformationByUserId(UserInformation userDetails);
    }
}
