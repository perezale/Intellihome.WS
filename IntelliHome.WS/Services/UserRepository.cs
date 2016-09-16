using IntelliHome.WS.Models.Db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IntelliHome.WS.Services
{
    public class UserRepository
    {
        public List<User> FindAll()
        {
            using(var context = new IntellihomeContext())
            {
                return context.User.ToList();
            }
        }

        public User FindById(int userId)
        {
            using (var context = new IntellihomeContext())
            {
                return context.User.FirstOrDefault(u => u.Id.Equals(userId));
            }
        }

    }
}