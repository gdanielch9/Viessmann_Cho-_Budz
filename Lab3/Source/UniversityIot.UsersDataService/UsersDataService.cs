namespace UniversityIot.UsersDataService
{
    using System;
    using System.Threading.Tasks;
    using UniversityIot.UsersDataAccess;
    using UniversityIot.UsersDataAccess.Models;

    public class UsersDataService : IUsersDataService
    {
        public async Task<User> AddUserAsync(User user)
        {
            using (var contex = new UsersContext())
            {
                contex.Users.Add(user);

                await contex.SaveChangesAsync();
            }

           return user;
        }

        public Task DeleteUserAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<User> GetUserAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<User> UpdateUserAsync(User user)
        {
            throw new NotImplementedException();
        }
    }
}