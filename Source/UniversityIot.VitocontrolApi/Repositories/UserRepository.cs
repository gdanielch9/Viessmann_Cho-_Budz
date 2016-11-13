using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Configuration;
using System.Web;
using UniversityIot.VitocontrolApi.Entities;

namespace UniversityIot.VitocontrolApi.Repositories
{
    public class UserRepository : IUserRepository
    {

        public List<User> Users;


        public User GetUserByUserName(string userName)
        {
            var user = new User();

            return user;
        }

        public bool CreateUser(User user)
        {
            var userExist = Users.Any(u => u.FullName == user.FullName);
            if (userExist)
            {
                return false;
            }
            Users.Add(user);

            return true;
        }

        public bool DeleteUser(User user)
        {
            var userExist = Users.Any(u => u.FullName == user.FullName);
            if (!userExist)
            {
                return false;
            }
            Users.Remove(user);

            return true;
        }




    }
}