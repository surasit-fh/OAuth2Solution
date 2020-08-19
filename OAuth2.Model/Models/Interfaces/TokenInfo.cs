using OAuth2.Model.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace OAuth2.Model.Models.Interfaces
{
    public class TokenInfo
    {
        public string TokenId { get; set; }
        public string AccessToken { get; set; }
        public TokenType TokenType { get; set; }
        public string ExpiresIn { get; set; }
        public string RefreshToken { get; set; }
        public string[] Scopes { get; set; }
    }
}