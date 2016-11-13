using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityIot.VitocontrolApi.Entities;

namespace UniversityIot.VitocontrolApi.Repositories
{
    public interface IUserRepository
    {

        User GetUserByUserName(string userName);

    }
}
