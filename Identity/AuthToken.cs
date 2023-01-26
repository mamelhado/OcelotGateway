using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Identity
{
    public class AuthToken
    {
        public string Token { get; set; }

        public DateTime ExpirationDate { get; set; }
    }

    public static class AuthTokenExtensions 
    {
        public static AuthToken GenerateToken(AuthUser user) 
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("this is my custom Secret key for authentication"));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);
            var expirationDate = DateTime.UtcNow.AddHours(2);

            var claims = new[] 
            {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.Name, user.UserName.ToString()),
                new Claim("Role","admin")
            };

            var token = new JwtSecurityToken(audience: "apiAudience",
                issuer: "apiIssuer",
                claims: claims,
                expires: expirationDate,
                signingCredentials: credentials);

            var authToken = new AuthToken() 
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                ExpirationDate = expirationDate
            };

            return authToken;
        }
    }
}
