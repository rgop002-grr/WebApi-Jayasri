namespace WebApi_Jayasri.Controllers.Models
{
    public class LoginModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }

    public class TokenRequest
    {
        public string RefreshToken { get; set; }
    }

    public class RefreshToken
    {
        public string Token { get; set; }
        public DateTime Created { get; set; }
        public DateTime Expires { get; set; }

        public bool IsExpired => DateTime.UtcNow >= Expires;
    }
}
    

