using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using UniversityIot.VitocontrolApi.Repositories;
using UniversityIot.VitocontrolApi.Services;

namespace UniversityIot.VitocontrolApi.Tests
{
    [TestFixture]
    public class UserServiceTest
    {

        private Mock<UserRepository> _userRepositoryMock;
        private UserService _sut;


        [Test]
        void WhenUserExistThenMethodGetUserShouldReturnUserName()
        {
            //Arrange
            var userName = "John Smith";

            

            //Act 

           // var user = GetUser(userName);


            //Assert



        }









    }
}
