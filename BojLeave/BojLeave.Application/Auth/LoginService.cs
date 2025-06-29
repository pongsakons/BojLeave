using System.Security.Claims;
using BojLeave.Domain.Repositories;
using BojLeave.Domain.Entities;

namespace BojLeave.Application.Auth
{
    public interface ILoginService
    {
        (bool Success, User? User, IEnumerable<Claim>? Claims) Login(string username, string password);
    }

    public class LoginService : ILoginService
    {
        private readonly IUserRepository _userRepository;
        public LoginService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public (bool Success, User? User, IEnumerable<Claim>? Claims) Login(string username, string password)
        {
            var user = _userRepository.GetByUsername(username);
            if (user == null || user.Username != username || user.Username != password)
                return (false, null, null);

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Username),
                new Claim("displayName", user.DisplayName)
            };
            claims.AddRange(user.Roles.Select(r => new Claim(ClaimTypes.Role, r)));
            return (true, user, claims);
        }
    }
}
