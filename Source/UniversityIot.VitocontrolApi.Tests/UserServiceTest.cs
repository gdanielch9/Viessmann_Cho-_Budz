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
     class UserServiceTest
    {

        private Mock<IUserRepository> _userRepositoryMock;
        private UserService _sut;

        [SetUp]
        public void SetUp()
        {
            _userRepositoryMock = new Mock<IUserRepository>();
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
        public void WhenUserDoesntExistThenMethodGetUserShouldFail()
        {
            //Arrange
            var userName = "John Smith";

            _userRepositoryMock.Setup(s => s.GetUserByUserName(It.IsAny<string>()))
                .Returns(new User());

            //Act
            var user = _sut.GetUser(userName);

            //Assert
            Assert.AreEqual(null,user.FullName);       
        }

        [Test]
        public void WhenUserExistThenCannotAllowToCreateUserWithTheSameName()
        {
            //Arrange
            var newUser = new User()
            {
                Contact = "contact",
                FullName = "Bob Trump"
            };

            _userRepositoryMock.Setup(s => s.CreateUser(It.IsAny<User>()))
                .Returns(false);

            //Act
            var user = _sut.CreateUser(newUser);

            //Assert
            Assert.AreEqual(false,user);
        }

        [Test]
        public void WhenCreateUserThenShouldCreateNewUserAndReturnTrueAsBoolean()
        {
            //Arrange
            var newUser = new User()
            {
                Contact = "contact",
                FullName = "Bob Trump"
            };

            _userRepositoryMock.Setup(s => s.CreateUser(It.IsAny<User>()))
                .Returns(true);

            //Act
            var user = _sut.CreateUser(newUser);

            //Assert
            Assert.AreEqual(true, user);
        }

        [Test]
        public void WhenDeleteUserCalledAndUserExistThenShouldDeleteUser()
        {
            //Arrange

            var userToDelete = new User()
            {
                Contact = "contact",
                FullName = "Bob Trump"
            };

            _userRepositoryMock.Setup(s => s.DeleteUser(It.IsAny<User>()))
                .Returns(true);

            //Act
            var user = _sut.DeleteUser(userToDelete);

            //Assert
            Assert.AreEqual(true, user);
        }

        [Test]
        public void WhenDeleteUserCalledAndUserDoesntExistThenShouldReturnFalse()
        {
            //Arrange

            var userToDelete = new User()
            {
                Contact = "contact",
                FullName = "Bob Trump"
            };

            _userRepositoryMock.Setup(s => s.DeleteUser(It.IsAny<User>()))
                .Returns(false);

            //Act
            var user = _sut.DeleteUser(userToDelete);

            //Assert
            Assert.AreEqual(false, user);
        }




    }
}
