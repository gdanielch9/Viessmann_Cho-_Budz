using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityIot.UsersDataAccess.Models;
using UniversityIot.UsersService.Models;

namespace UniversityIot.UsersService.Infrastructure
{
    public interface IMappingInfrastructure
    {
        UserViewModel MapUserToUserViewModel(User user);
        User MapUserViewModelToUser(UserViewModel userViewModel);
        User MapAddUserViewModelToUser(AddUserViewModel addUserViewModel);
    }
}
