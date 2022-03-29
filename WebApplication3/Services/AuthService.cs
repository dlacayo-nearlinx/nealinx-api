using Nearlinx.nearlinxApi.crud.Model;
using Microsoft.Extensions.Configuration;
using Nearlinx.nearlinxApi.crud.Helpers;
namespace Nearlinx.nearlinxApi.crud.Services
{



  public class AuthService
  {

    private readonly string _secret;
    public AuthService(string secret)
    {
      _secret = secret;
    }

    public AuthResponse Login(Auth userAuth)
    {
      var jwt = new JsonWebToken(this._secret);
      var myToken = jwt.createJWT(userAuth);

      return new AuthResponse(true, myToken);
    }



  }


}