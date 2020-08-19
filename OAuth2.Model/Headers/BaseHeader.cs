using Microsoft.AspNetCore.Mvc;
using OAuth2.Model.ValidationAttributeHandles;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;

namespace OAuth2.Model.Headers
{
    [ModelBinder(BinderType = typeof(FromHeaderBinder))]
    public class BaseHeader
    {
        [FromHeader]
        [DataMember(Name = "Authorization")]
        [Required]
        public string Authorization { get; set; }
    }
}