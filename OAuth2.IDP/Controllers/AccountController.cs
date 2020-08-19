using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OAuth2.IDP.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class AccountController : Controller
    {
        [HttpPost("Login")]
        public string Login()
        {
            return "Login is success";
        }

        [HttpPost("Logout")]
        public string Logout()
        {
            return "Logout is success";
        }
    }
}