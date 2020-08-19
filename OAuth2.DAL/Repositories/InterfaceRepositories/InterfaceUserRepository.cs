using OAuth2.Model.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace OAuth2.DAL.Repositories.InterfaceRepositories
{
    public interface InterfaceUserRepository
    {
        List<UserInfo> GetUserAll();
        UserInfo GetUserById(string userId);
        List<UserInfo> GetUserByCriteria(UserInfo userInfo);
        string InsertUser(UserInfo userInfo);
        bool UpdateUser(UserInfo userInfo);
        bool DeleteUser(string userId);
    }
}