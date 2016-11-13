﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityIot.VitocontrolApi.Entities;
using UniversityIot.VitocontrolApi.Repositories;

namespace UniversityIot.VitocontrolApi.Services
{
    public class UserService: IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }


        public User GetUser(string userName)
        {

            var user = _userRepository.GetUserByUserName(userName);
            return user;

        }

        public bool CreateUser(User user)
        {
            var userCreated  = _userRepository.CreateUser(user);
            return userCreated;
        }

        public bool DeleteUser(User user)
        {
            var userDeleted = _userRepository.DeleteUser(user);
            return userDeleted;
        }

    }
}