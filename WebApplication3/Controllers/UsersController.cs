using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Nearlinx.nearlinxApi.crud.Helpers;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Authorization;
using Nearlinx.nearlinxApi.crud.Model;
using Nearlinx.nearlinxApi.crud.Services;

namespace Nearlinx.nearlinxApi.crud.Controllers
{
  [ApiController]
  [Route("[controller]")]
  [Authorize]
  public class UsersController : ControllerBase
  {

    private readonly ILogger<UsersController> _logger;
    private readonly IConfiguration _config;
    public UsersController(ILogger<UsersController> logger, IConfiguration config)
    {
      _logger = logger;
      this._config = config;
    }

    [HttpGet]
    public ActionResult<List<User>> GetUsers()
    {
      var users = UserService.GetInstance();
      return Ok(users.GetUsers());
    }

    [HttpGet("id")]
    public ActionResult<User> GetUser(int id)
    {
      var users = UserService.GetInstance();
      return Ok(users.GetUser(id));
    }

    [HttpPost]
    public ActionResult<List<User>> AddUsers([FromBody] User user)
    {
      var users = UserService.GetInstance();
      users.AddUser(user);
      return Ok(users.GetUsers());
    }


    [HttpPut]
    public User UpdateUser([FromBody] User user)
    {
      var users = UserService.GetInstance();
      var userUpdated = users.UpdateUser(user);


      return userUpdated;
    }


    [HttpDelete("id")]
    public bool RemoveUser(int id)
    {
      var users = UserService.GetInstance();
      bool resp = users.RemoveUser(id);
      return resp;
    }
  }
}
