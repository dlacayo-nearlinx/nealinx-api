using Microsoft.AspNetCore.Mvc;
using Nearlinx.nearlinxApi.crud.Model;
using Nearlinx.nearlinxApi.crud.Services;
using Microsoft.Extensions.Configuration;
using System;

namespace Nearlinx.nearlinxApi.crud.Controllers
{
  [Route("[controller]")]
  [ApiController]
  public class AuthController : ControllerBase
  {
    private const int MIN_USER_LENGTH = 5;
    private const int MIN_PASS_LENGTH = 5;
    private readonly IConfiguration _config;
    public AuthController(IConfiguration config)
    {
      _config = config;
    }


    [HttpPost("login")]
    public AuthResponse Login([FromBody] Auth userAuth)
    {
      if (userAuth.Username.Length < MIN_USER_LENGTH || userAuth.Password.Length < MIN_PASS_LENGTH)
      {
        return new AuthResponse(false, "");
      }

      var authService = new AuthService(this._config.GetValue<string>("Secret"));
      var authResponse = authService.Login(userAuth);

      return authResponse;
    }
  }
}
