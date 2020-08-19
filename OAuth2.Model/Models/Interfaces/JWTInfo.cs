using System;
using System.Collections.Generic;
using System.Text;

namespace OAuth2.Model.Models.Interfaces
{
    public class JWTInfo
    {
        public Header Header { get; set; }
        public Payload Payload { get; set; }
        public string Signature { get; set; }
    }

    public class Header
    {

    }

    public class Payload
    {

    }
}