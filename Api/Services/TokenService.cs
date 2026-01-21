using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Api.Features.Users.Models;
using Microsoft.IdentityModel.Tokens;

namespace Api.Services;

public static class TokenService
{
    public static string Key { get; set; } = string.Empty;

    extension(User user)
    {
        public string GenerateToken()
        {
            var handler = new JwtSecurityTokenHandler();
            var keyBytes = Encoding.UTF8.GetBytes(Key);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Expires = DateTime.UtcNow.AddHours(4),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(keyBytes), SecurityAlgorithms.HmacSha256),
                Issuer = "ServerApi",
                Audience = "ClientApi",

                Subject = new ClaimsIdentity([
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                ])
            };

            var token = handler.CreateToken(tokenDescriptor);
            return handler.WriteToken(token);
        }
    }
}