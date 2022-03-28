using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;
using WebApplication3.Controllers;
using System;

namespace WebApplication3.Jwt
{
  public class JsonWebToken
  {
    private readonly byte[] _secret;

    public JsonWebToken(string @secretkey)
    {
      _secret = Encoding.ASCII.GetBytes(secretkey);
    }


    public string createJWT(User user)
    {
      var claims = new ClaimsIdentity();

      claims.AddClaim(new Claim(ClaimTypes.NameIdentifier, user.name));
      claims.AddClaim(new Claim(ClaimTypes.NameIdentifier, user.id + ""));
      claims.AddClaim(new Claim(ClaimTypes.Role, user.rol));

      var tokenDesc = new SecurityTokenDescriptor()
      {
        Subject = claims,
        Expires = DateTime.UtcNow.AddHours(5),
        SigningCredentials =
              new SigningCredentials(new SymmetricSecurityKey(_secret),
                  SecurityAlgorithms.HmacSha256Signature)
      };

      var tokenHandler = new JwtSecurityTokenHandler();
      var token = tokenHandler.CreateToken(tokenDesc);
      return tokenHandler.WriteToken(token);
    }
  }
}