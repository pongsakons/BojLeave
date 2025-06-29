using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace BojLeave.Application.Auth
{
    public class JwtTokenGenerator : IJwtTokenGenerator
    {
        private readonly string _secretKey;
        private readonly string _issuer;
        private readonly string _audience;
        private readonly int _expiresHours;

        public JwtTokenGenerator(IConfiguration configuration)
        {
            _secretKey = configuration["Jwt:SecretKey"] ?? throw new ArgumentNullException("Jwt:SecretKey");
            _issuer = configuration["Jwt:Issuer"] ?? throw new ArgumentNullException("Jwt:Issuer");
            _audience = configuration["Jwt:Audience"] ?? throw new ArgumentNullException("Jwt:Audience");
            _expiresHours = int.TryParse(configuration["Jwt:ExpiresHours"], out var h) ? h : 1;
        }

        public string GenerateToken(string username, IEnumerable<Claim> claims)
        {
            var claimsList = claims?.ToList() ?? new List<Claim>();
            if (!claimsList.Any(c => c.Type == ClaimTypes.Name))
            {
                claimsList.Add(new Claim(ClaimTypes.Name, username));
            }
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_secretKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _issuer,
                audience: _audience,
                claims: claimsList,
                expires: DateTime.Now.AddHours(_expiresHours),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public string RefreshToken(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            SecurityToken validatedToken;
            var validationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = false, // ไม่ตรวจสอบอายุ token เดิม
                ValidateIssuerSigningKey = true,
                ValidIssuer = _issuer,
                ValidAudience = _audience,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_secretKey))
            };

            var principal = tokenHandler.ValidateToken(token, validationParameters, out validatedToken);
            var username = principal.Identity?.Name ?? principal.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name)?.Value;
            if (string.IsNullOrEmpty(username))
                throw new SecurityTokenException("Invalid token: missing username");

            // สร้าง token ใหม่โดยใช้ claims เดิม
            return GenerateToken(username, principal.Claims);
        }
    }
}
