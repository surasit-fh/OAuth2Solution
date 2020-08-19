using OAuth2.Model.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OAuth2.IDP.Models.Requests
{
    public class AccountRequest
    {
        public AuthenticationInfo AuthenticationInfo { get; set; }
        public TokenInfo TokenInfo { get; set; }
    }
}