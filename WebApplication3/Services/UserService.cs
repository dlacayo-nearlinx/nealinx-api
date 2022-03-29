using System.Collections.Generic;
using Nearlinx.nearlinxApi.crud.Model;


namespace Nearlinx.nearlinxApi.crud.Services
{
  class UserService
  {
    public static UserService data;
    private List<User> UserList = new List<User>();

    private UserService() { }

    public static UserService GetInstance()
    {
      if (data == null)
      {
        data = new UserService();
      }
      return data;
    }

    public List<User> GetUsers()
    {
      return this.UserList;
    }

    public User GetUser(int id)
    {
      for (int i = 0; i < this.UserList.Count; i++)
      {
        if (this.UserList[i].id == id)
        {
          return this.UserList[i];
        }
      }
      return new User();
    }

    public bool AddUser(User user)
    {
      this.UserList.Add(user);
      return true;
    }

    public bool RemoveUser(int id)
    {
      for (int i = 0; i < this.UserList.Count; i++)
      {
        if (this.UserList[i].id == id)
        {
          UserList.RemoveAt(i);
          return true;
        }
      }
      return false;
    }

    public User UpdateUser(User userToUpdate)
    {

      foreach (var user in this.UserList)
      {
        if (user.id == userToUpdate.id)
        {
          user.name = userToUpdate.name;
          user.rol = userToUpdate.rol;
          return user;
        }
      }

      return new User();
    }

  }


}