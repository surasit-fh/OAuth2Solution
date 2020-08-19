using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OAuth2.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ImageController : Controller
    {
        [HttpGet("GetImageAll")]
        public string GetImageAll()
        {
            return "Get images is success";
        }
    }
}