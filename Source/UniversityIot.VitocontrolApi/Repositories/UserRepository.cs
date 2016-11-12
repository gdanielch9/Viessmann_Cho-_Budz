using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityIot.VitocontrolApi.Entities;

namespace UniversityIot.VitocontrolApi.Repositories
{
    public class UserRepository : IUserRepository
    {

        public User GetUserByUserName(string userName)
        {
            var user = new User();

            return user;
        }






    }
}