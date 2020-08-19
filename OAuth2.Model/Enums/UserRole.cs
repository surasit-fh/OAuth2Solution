using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace OAuth2.Model.Enums
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum UserRole : int
    {
        [Description("None")]
        None = 0,

        [Description("Admin")]
        Admin = 1,

        [Description("User")]
        User = 2
    }
}