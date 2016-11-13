using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using UniversityIot.VitocontrolApi.Entities;
using UniversityIot.VitocontrolApi.Repositories;
using UniversityIot.VitocontrolApi.Services;

namespace UniversityIot.VitocontrolApi.Tests
{
    [TestFixture]
    public class UserServiceTest
    {

        private Mock<UserRepository> _userRepositoryMock;
        private UserService _sut;

        [SetUp]
        public void SetUp()
        {
            _userRepositoryMock = new Mock<UserRepository>();
            _sut = new UserService(_userRepositoryMock.Object);
        }


        [Test]
        public void WhenUserExistThenMethodGetUserShouldReturnUserName()
        {
            //Arrange
            var userName = "John Smith";

            _userRepositoryMock.Setup(s => s.GetUserByUserName(It.IsAny<string>()))
                .Returns(new User() {FullName = "John Smith", Contact = "123456789"});

            //Act 

            var user = _sut.GetUser(userName);


            //Assert
            Assert.AreEqual(userName,user.FullName);


        }


        [Test]

        public void SampleTest()
        {

            //Arrange
            var userName = "John Smith";

            //_userRepositoryMock.Setup(s => s.GetUserByUserName(It.IsAny<string>()))
            //    .Returns(new User() { FullName = "John Smith", Contact = "123456789" });

            ////Act 

            //var user = _sut.GetUser(userName);


            ////Assert
            //Assert.AreEqual(userName, user.FullName);


        }






    }
}
