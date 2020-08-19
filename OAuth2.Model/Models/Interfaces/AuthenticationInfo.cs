using OAuth2.Model.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace OAuth2.Model.Models.Interfaces
{
    public class AuthenticationInfo
    {
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
        public GrantType GrantType { get; set; }
        public string Code { get; set; }
        public string[] Scopes { get; set; }
        public string RedirectURI { get; set; }
    }
}