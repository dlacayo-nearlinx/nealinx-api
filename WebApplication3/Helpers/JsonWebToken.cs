using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;
using Nearlinx.nearlinxApi.crud.Model;
using System;

namespace Nearlinx.nearlinxApi.crud.Helpers
{
  public class JsonWebToken
  {
    private readonly byte[] _secret;

    public JsonWebToken(string @secretkey)
    {
      _secret = Encoding.ASCII.GetBytes(secretkey);
    }


    public string createJWT(Auth user)
    {
      var claims = new ClaimsIdentity();

      claims.AddClaim(new Claim(ClaimTypes.NameIdentifier, user.Username));

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