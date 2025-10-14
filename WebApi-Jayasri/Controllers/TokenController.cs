using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace WebApi_Jayasri.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        // 🔑 Secret key (make sure it’s at least 32 characters)
        private readonly string secretKey = "ThisIsMyUltraSuperSecretKeyForJWT123456";

        // 🧾 Model for login request
        public class LoginRequest
        {
            public string Username { get; set; }
            public string Password { get; set; }
        }

        // 🔐 POST: api/token/login
        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequest request)
        {
            // ✅ Step 1: Validate user (hardcoded for demo)
            if (request.Username == "admin" && request.Password == "password")
            {
                // ✅ Step 2: Create claims (payload)
                var claims = new[]
                {
                    new Claim(ClaimTypes.Name, request.Username),
                    new Claim(ClaimTypes.Role, "Admin"),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                };

                // ✅ Step 3: Create key & credentials
                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                // ✅ Step 4: Generate token
                var token = new JwtSecurityToken(
                    issuer: "yourapp.com",
                    audience: "yourapp.com",
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(30),
                    signingCredentials: creds
                );

                // ✅ Step 5: Return token
                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token),
                    expiration = token.ValidTo
                });
            }

            return Unauthorized("Invalid username or password");
        }
    }
}


