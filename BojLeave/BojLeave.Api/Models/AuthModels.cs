namespace BojLeave.Api.Models
{
    public class LoginRequest
    {
        public string? Username { get; set; }
        public string? Password { get; set; }
    }

    public class RefreshTokenRequest
    {
        public string? Token { get; set; }
    }
}
