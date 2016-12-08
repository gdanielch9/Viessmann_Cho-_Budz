namespace UniversityIot.UsersDataService
{
    using System.Threading.Tasks;
    using GatewaysDataAccess;
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

        public async Task DeleteUserAsync(int id)
        {
            using (var contex = new UsersContext())
            {
                var user = contex.Users.Find(id);

                if (user != null)
                {
                    contex.Users.Remove(user);
                    await contex.SaveChangesAsync();
                }
            }
        }

        public async Task<User> GetUserAsync(int id)
        {
            User user;
            using (var contex = new UsersContext())
            {
                user = contex.Users.Find(id);
            }

            return user;
        }

        public async Task<User> UpdateUserAsync(User user)
        {
            using (var contex = new UsersContext())
            {
                var oldUser = contex.Users.Find(user.Id);
                contex.Users.Remove(oldUser);
                contex.Users.Add(user);

                await contex.SaveChangesAsync();
            }

            return user;
        }
    }
}