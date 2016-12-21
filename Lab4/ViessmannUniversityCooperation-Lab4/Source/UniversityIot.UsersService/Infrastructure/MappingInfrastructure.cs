using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using UniversityIot.UsersDataAccess.Models;
using UniversityIot.UsersService.Models;

namespace UniversityIot.UsersService.Infrastructure
{
    public class MappingInfrastructure: IMappingInfrastructure
    {

        private readonly IMapper _mapper;
        public MappingInfrastructure(IMapper mapper)
        {
            _mapper = mapper;
        }

        public User MapAddUserViewModelToUser(AddUserViewModel addUserViewModel)
        {
            var user = _mapper.Map<AddUserViewModel, User>(addUserViewModel);
            return user;
        }

        public UserViewModel MapUserToUserViewModel(User user)
        {
            var uverViewModel = _mapper.Map<User, UserViewModel>(user);
            return uverViewModel;
        }

        public User MapUserViewModelToUser(UserViewModel userViewModel)
        {
            var user = _mapper.Map<UserViewModel, User>(userViewModel);
            return user;
        }
    }
}