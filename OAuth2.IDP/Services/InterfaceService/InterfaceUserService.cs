using OAuth2.Model.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OAuth2.IDP.Services.InterfaceService
{
    public interface InterfaceUserService
    {
        List<UserInfo> GetUserAll();
        UserInfo GetUserById(UserInfo userInfo);
        List<UserInfo> GetUserByCriteria(UserInfo userInfo);
        string InsertUser(UserInfo userInfo);
        bool UpdateUser(UserInfo userInfo);
        bool DeleteUser(UserInfo userInfo);
    }
}