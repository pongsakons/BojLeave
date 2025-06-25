using BojLeave.Application.Auth;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using BojLeave.Api.Models;

namespace BojLeave.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly ILoginService _loginService;
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly BojLeave.Domain.Repositories.IUserRepository _userRepository;
        public AuthController(ILoginService loginService, IJwtTokenGenerator jwtTokenGenerator, BojLeave.Domain.Repositories.IUserRepository userRepository)
        {
            _loginService = loginService;
            _jwtTokenGenerator = jwtTokenGenerator;
            _userRepository = userRepository;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequest request)
        {
            if (string.IsNullOrEmpty(request.Username) || string.IsNullOrEmpty(request.Password))
                return Unauthorized();
            if (!_loginService.ValidateUser(request.Username, request.Password))
                return Unauthorized();

            var user = _userRepository.GetByUsername(request.Username);
            if (user == null)
                return Unauthorized();

            var claims = new[]
            {
                new Claim(ClaimTypes.Name, user.Username),
                new Claim("displayName", user.DisplayName),
            }.Concat(user.Roles.Select(r => new Claim(ClaimTypes.Role, r)));

            var token = _jwtTokenGenerator.GenerateToken(user.Username, claims);
            var userInfo = new
            {
                user.Username,
                user.DisplayName,
                user.Roles
            };
            return Ok(new { token, user = userInfo });
        }

        [HttpPost("refresh")]
        public IActionResult RefreshToken([FromBody] RefreshTokenRequest request)
        {
            if (string.IsNullOrEmpty(request.Token))
                return BadRequest("Token is required");
            try
            {
                var newToken = _jwtTokenGenerator.RefreshToken(request.Token);
                return Ok(new { token = newToken });
            }
            catch (Exception ex)
            {
                return Unauthorized(new { error = ex.Message });
            }
        }
    }
}
