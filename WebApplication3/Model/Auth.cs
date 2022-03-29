using Microsoft.AspNetCore.Mvc;


namespace Nearlinx.nearlinxApi.crud.Model
{


  public class Auth
  {
    public string Username { get; set; }
    public string Password { get; set; }


    public Auth(string username, string password)
    {
      Username = username;
      Password = password;
    }
  }

  public class AuthResponse
  {
    public bool IsAuthenticated { get; set; }
    public string Token { get; set; }


    public AuthResponse(bool isAuthenticated, string token)
    {
      IsAuthenticated = isAuthenticated;
      Token = token;
    }
  }
}