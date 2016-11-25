﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityIot.VitocontrolApi.Entities;

namespace UniversityIot.VitocontrolApi.Services
{
    public interface IUserService
    {
        User GetUser(string userName);
        bool CreateUser(User user);
    }
}
