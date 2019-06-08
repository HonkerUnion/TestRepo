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
    public class UserInformationServices : IUserInfoServices
    {
        private readonly UnitOfWork _unitOfWork;

        /// <summary>
        /// Public constructor.
        /// </summary>
        public UserInformationServices()
        {
            _unitOfWork = new UnitOfWork();
        }

        /// <summary>
        /// Fetches userinformation by userId
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        public List<UserInformation> getUserInformationByUserId(int userId)
        {
            var userInfomations = _unitOfWork.UserInformationRepository.GetAll().ToList().Where(u => u.USERID == userId).ToList();
            if (userInfomations != null)
            {
                var config = new MapperConfiguration(cfg => cfg.CreateMap<USERINFORMATION, UserInformation>());
                var mapper = config.CreateMapper();
                var userInformationModel = mapper.Map<List<USERINFORMATION>, List<UserInformation>>(userInfomations);
                return userInformationModel;
            }
            return null;
        }

        public void SaveUserInformationByUserId(UserInformation userDetails)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<UserInformation, USERINFORMATION>());
            var mapper = config.CreateMapper();
            var userInformationModel = mapper.Map<UserInformation, USERINFORMATION>(userDetails);
             _unitOfWork.UserInformationRepository.Insert(userInformationModel);
        }



    }
}
