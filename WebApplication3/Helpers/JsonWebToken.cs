
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authentication;
using WebApplication3.Controllers;
using System;

namespace WebApplication3.Jwt
{
    public class JsonWebToken
    {
        private byte[] SECRET;

        public JsonWebToken(string @secretkey)
        {
            
            this.SECRET =  Encoding.ASCII.GetBytes(secretkey);

        }
  

        public string createJWT(User user)
        {

            var claims = new ClaimsIdentity();

            claims.AddClaim(new Claim(ClaimTypes.NameIdentifier, user.name));
            claims.AddClaim(new Claim(ClaimTypes.NameIdentifier, user.password));
            claims.AddClaim(new Claim(ClaimTypes.NameIdentifier, user.rol));

            var tokenDesc = new SecurityTokenDescriptor()
            {
                Subject = claims,
                Expires = DateTime.UtcNow.AddHours(5),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(this.SECRET), SecurityAlgorithms.HmacSha256Signature)
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.CreateToken(tokenDesc);

            return tokenHandler.WriteToken(token);
    
        }


        public bool decodeJWT(string token)
        {

            var tokenHandler = new JwtSecurityTokenHandler();

            var securityToken = new JwtSecurityToken(token);

      



            return false;
        }



    }
}
