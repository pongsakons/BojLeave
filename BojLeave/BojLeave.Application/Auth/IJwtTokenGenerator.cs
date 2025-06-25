using System.Security.Claims;

namespace BojLeave.Application.Auth
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(string username, IEnumerable<Claim> claims);
        string RefreshToken(string token);
    }
}
