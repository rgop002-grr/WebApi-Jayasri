using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi_Jayasri.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Tokenvalidation : ControllerBase
    {
        [HttpGet("data")]
        public IActionResult GetSecureData()
        {
            var username = User.Identity?.Name;
            return Ok(new
            {
                Message = $"Hello {username}, you have accessed a protected endpoint!"
            });
        }

    }
}
