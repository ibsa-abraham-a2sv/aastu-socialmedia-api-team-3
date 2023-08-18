

using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Galacticos.Application.Common.Interface.Authentication;
using Microsoft.IdentityModel.Tokens;

namespace Galacticos.Infrastructure.Authentication;

public class JwtTokenGenerator : IJwtTokenGenerator{
    
    public string GenerateToken(Guid userId, string username, string password){

        var signingCredentials = new SigningCredentials(
            new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes("super-secret-key-that-is-long-enough-to-be-secure")),
                SecurityAlgorithms.HmacSha256
        );

        var claims = new List<Claim>
        {
            new Claim(JwtRegisteredClaimNames.Sub, userId.ToString()),
            new Claim(JwtRegisteredClaimNames.UniqueName, username),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
        };

        var securityToken = new JwtSecurityToken(
            issuer: "Galacticos",
            claims: claims,
            expires: DateTime.UtcNow.AddHours(1),
            signingCredentials: signingCredentials
        );

        return new JwtSecurityTokenHandler().WriteToken(securityToken);
    }
}