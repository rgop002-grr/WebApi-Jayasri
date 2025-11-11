using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using WebApi_Jayasri.Controllers.Models;


namespace WebApi_Jayasri.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RefreshTokenController : ControllerBase
    {
        private readonly IConfiguration _config;
        private static List<RefreshToken> refreshTokens = new();

        public RefreshTokenController(IConfiguration config)
        {
            _config = config;
        }

        // 🔹 LOGIN → Generate Access + Refresh Token
        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginModel login)
        {
            if (login.Username != "admin" || login.Password != "1234")
                return Unauthorized("Invalid credentials");

            var accessToken = GenerateAccessToken(login.Username);
            var refreshToken = GenerateRefreshToken();

            refreshTokens.Add(refreshToken);

            return Ok(new
            {
                AccessToken = accessToken,
                RefreshToken = refreshToken.Token
            });
        }

        // 🔹 REFRESH → Generate new tokens using refresh token
        [HttpPost("refresh")]
        public IActionResult Refresh([FromBody] TokenRequest request)
        {
            var storedToken = refreshTokens.FirstOrDefault(t => t.Token == request.RefreshToken);

            if (storedToken == null || storedToken.IsExpired)
                return Unauthorized("Invalid or expired refresh token");

            // Remove old refresh token
            refreshTokens.Remove(storedToken);

            // Generate new tokens
            var newAccessToken = GenerateAccessToken("admin");
            var newRefreshToken = GenerateRefreshToken();
            refreshTokens.Add(newRefreshToken);

            return Ok(new
            {
                AccessToken = newAccessToken,
                RefreshToken = newRefreshToken.Token
            });
        }

        // 🔸 Helper: Create short-lived Access Token
        private string GenerateAccessToken(string username)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, username),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:secretKey"]));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(5),  // Access token valid for 2 mins
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        // 🔸 Helper: Create long-lived Refresh Token
        private RefreshToken GenerateRefreshToken()
        {
            return new RefreshToken
            {
                Token = Convert.ToBase64String(RandomNumberGenerator.GetBytes(64)),
                Expires = DateTime.UtcNow.AddDays(7),
                Created = DateTime.UtcNow
            };
        }
    }
}
