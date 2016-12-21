using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using UniversityIot.UsersDataAccess.Models;
using UniversityIot.UsersService.Models;

namespace UniversityIot.UsersService
{
    public static class AutoMapperConfiguration
    {
        public static IMapper ConfigureMapper()
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<UserViewModel, User>();
                cfg.CreateMap<User, UserViewModel>();
                
            });
            var mapper = configuration.CreateMapper();
            return mapper;
        }

    }
}