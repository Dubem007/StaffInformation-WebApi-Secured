using Microsoft.AspNetCore.Mvc;
using StaffInformation.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StaffInformation.Controllers
{
    
    [ApiController]
    [Route("[controller]")]
    public class JwtController : ControllerBase
    {
        [HttpGet]
        public IActionResult Jwt() 
        {
            return new ObjectResult(JwtToken.GenerateJwtToken());
        }
    }
}
