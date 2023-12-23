using Innoplatforma.Server.Domain.Entities.Users;
using Innoplatforma.Server.Service.Interfaces.Commons;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Innoplatforma.Server.Service.Services.Commons;

public class AuthService : IAuthService
{
    private readonly IConfiguration _configuration;
    public AuthService(IConfiguration configuration)
    {
        _configuration = configuration.GetSection("Jwt");
    }

    public string GenerateToken(User user)
    {
        var claims = new[]
        {

            new Claim("Id", user.Id.ToString()),
            new Claim(ClaimTypes.Name, user.FirstName+ " " + user.LastName),
            new Claim("PhoneNumber", user.Phone),
            new Claim(ClaimTypes.Role, user.Role.Name)
        };

        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["SecretKey"]));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);
        var tokenDescriptor = new JwtSecurityToken(_configuration["Issuer"], _configuration["Audience"], claims,
            expires: DateTime.Now.AddMinutes(double.Parse(_configuration["Lifetime"])),
            signingCredentials: credentials);

        return new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);
    }
}
