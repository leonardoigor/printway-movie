using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Movie.Domain.Entities;

namespace Movie.Api.Security;

public class TokenManager
{
    public Task<Token> GenerateTokenAsync(string email, string password)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var date = DateTime.UtcNow;
        var expires = date.AddMinutes(30);
        var key = Encoding.ASCII.GetBytes("12345678901234567890123456789012");
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.Name, email),
                new Claim(ClaimTypes.Role, "Admin")
            }),
            Expires = expires,
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256Signature)
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);
        var tokenString = tokenHandler.WriteToken(token);
        return Task.FromResult(new Token
        {
            Expires = expires,
            TokenString = tokenString
        });
    }
}
