using OAuth2.DAL.Repositories.Repositories;
using OAuth2.IDP.Services.InterfaceService;
using OAuth2.Model.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OAuth2.IDP.Services.Services
{
    public class UserService : InterfaceUserService
    {
        UserRepository _userRepository;

        public UserService()
        {
            this._userRepository = new UserRepository();
        }

        public List<UserInfo> GetUserAll()
        {
            try
            {
                List<UserInfo> listUserResponse = _userRepository.GetUserAll();
                return listUserResponse;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public UserInfo GetUserById(UserInfo userInfo)
        {
            try
            {
                UserInfo userResponse = _userRepository.GetUserById(userInfo.UserId);
                return userResponse;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<UserInfo> GetUserByCriteria(UserInfo userInfo)
        {
            try
            {
                List<UserInfo> listUserResponse = _userRepository.GetUserByCriteria(userInfo);
                return listUserResponse;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string InsertUser(UserInfo userInfo)
        {
            try
            {
                string userId = _userRepository.InsertUser(userInfo);
                return userId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool UpdateUser(UserInfo userInfo)
        {
            try
            {
                bool isSuccess = _userRepository.UpdateUser(userInfo);
                return isSuccess;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool DeleteUser(UserInfo userInfo)
        {
            try
            {
                bool isSuccess = _userRepository.DeleteUser(userInfo.UserId);
                return isSuccess;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}