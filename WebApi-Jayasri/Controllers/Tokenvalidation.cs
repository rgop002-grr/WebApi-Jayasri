using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi_Jayasri.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Tokenvalidation : ControllerBase
    {
        [Authorize]
        [HttpGet("Validate")]
        public IActionResult validateToken()
        {
            {
                return Ok("Authorized Successfully");
            }
        }
    }
}
