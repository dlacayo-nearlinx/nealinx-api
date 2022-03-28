using System.Collections.Generic;
using WebApplication3.Controllers;


namespace WebApplication3
{
  class ContainerData
  {
    public static ContainerData data;
    private List<User> UserList = new List<User>();

    private ContainerData() { }

    public static ContainerData GetInstance()
    {
      if (data == null)
      {
        data = new ContainerData();
      }
      return data;
    }

    public List<User> GetUsers()
    {
      return this.UserList;
    }

    public void AddUser(User user)
    {
      this.UserList.Add(user);
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

  }


}