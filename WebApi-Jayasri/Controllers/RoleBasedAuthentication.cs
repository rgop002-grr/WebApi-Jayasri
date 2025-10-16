using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi_Jayasri.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleBasedAuthentication : ControllerBase
    {
        // ✅ Only Admins can access
        [Authorize(Roles = "Admin")]
        [HttpGet("admin")]
        public IActionResult AdminAccess()
        {
            return Ok("Welcome Admin! You have access to admin-only resources.");
        }

        // ✅ Only normal Users can access
        [Authorize(Roles = "User")]
        [HttpGet("user")]
        public IActionResult UserAccess()
        {
            return Ok("Welcome User! You have access to user-only resources.");
        }

        // ✅ Any authenticated user (Admin/User)
        [Authorize]
        [HttpGet("common")]
        public IActionResult CommonAccess()
        {
            return Ok("Welcome! You are authenticated successfully.");
        }
    }
}

    
