using System.Security.Claims;

namespace BojLeave.Application
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(string username, IEnumerable<Claim> claims);
        string RefreshToken(string token);
    }
}
