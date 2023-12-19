using System.Security.Claims;
using Domain;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Application.DTOs.userAuthDto;

namespace API.Services;

public class AuthenticationTokenService
{
    
    private readonly IConfiguration _config;

    public AuthenticationTokenService(IConfiguration config)
    {
        _config = config;
    }
    public string CreateToken(User user)
    {
        var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.NameIdentifier, user.Id)
            };

        // TODO: move the token key to config file
        var tokenKey = _config["tokenKey"];
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenKey));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.UtcNow.AddDays(7),
            SigningCredentials = creds
        };
        var tokenHandler = new JwtSecurityTokenHandler();
        var token = tokenHandler.CreateToken(tokenDescriptor);

        return tokenHandler.WriteToken(token); ;

    }
    
    public UserDto CreateUserWithToken(User user)
    {
        var token = this.CreateToken(user);

        return new UserDto
        {
            Token  = token,
            Username = user.UserName
        };

    }
}
