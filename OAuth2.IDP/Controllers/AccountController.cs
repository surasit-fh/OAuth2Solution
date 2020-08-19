using Microsoft.AspNetCore.Mvc;
using OAuth2.IDP.Models.Requests;
using OAuth2.IDP.Models.Responses;
using OAuth2.IDP.Process;
using OAuth2.Model.Headers;
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
        [Consumes("application/json")]
        public AccountControlResponse Login([FromHeader]BaseHeader header, AccountRequest accountRequest)
        {
            AccountProcess accountProcess = new AccountProcess();
            AccountControlResponse response = accountProcess.LoginProcess(header.Authorization.Substring("Basic".Length).Trim(), accountRequest.AuthenticationInfo, accountRequest.TokenInfo);
            return response;
        }

        [HttpGet("Logout")]
        [Consumes("application/x-www-form-urlencoded")]
        public AccountControlResponse Logout([FromHeader]BaseHeader header)
        {
            AccountProcess accountProcess = new AccountProcess();
            AccountControlResponse response = accountProcess.LogoutProcess(header.Authorization.Substring("Bearer".Length).Trim());
            return response;
        }
    }
}