using OAuth2.Model.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace OAuth2.Model.Models.Interfaces
{
    public class UserInfo
    {
        public string UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public UserRole UserRole { get; set; }
        public string Code { get; set; }
    }
}