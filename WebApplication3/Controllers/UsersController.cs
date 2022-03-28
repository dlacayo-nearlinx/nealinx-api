using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApplication3.Jwt;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Authorization;

namespace WebApplication3.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class UsersController : ControllerBase
  {

    private readonly ILogger<UsersController> _logger;
    private readonly IConfiguration _config;
    public UsersController(ILogger<UsersController> logger, IConfiguration config)
    {
      _logger = logger;
      this._config = config;
    }


    [HttpPost("login")]
    public ActionResult<object> createJWT([FromBody] User user)
    {
      var keySecret = this._config.GetValue<string>("Secret");
      var jwt = new JsonWebToken(keySecret);
      var myToken = jwt.createJWT(user);
      return Ok(new
      {
        ok = true,
        token = myToken
      });
    }

    [HttpGet]
    [Authorize]
    public ActionResult<List<User>> GetUsers()
    {
      var data = ContainerData.GetInstance();
      return Ok(data.GetUsers());
    }

    [HttpGet("id")]
    public ActionResult<List<User>> GetUser(int id)
    {
      var data = ContainerData.GetInstance();
      return Ok(data.GetUser(id));
    }

    [HttpPost]
    public ActionResult<List<User>> AddUsers([FromBody] User user)
    {
      var data = ContainerData.GetInstance();
      data.AddUser(user);
      return Ok(data.GetUsers());
    }

    [HttpDelete("id")]
    public ActionResult RemoveUser(int id)
    {
      var data = ContainerData.GetInstance();
      bool resp = data.RemoveUser(id);
      return Ok(resp);
    }
  }


  public class User
  {

    public int id { get; set; }
    public string name { get; set; }
    public string password { get; set; }
    public string rol { get; set; }
  }
}
