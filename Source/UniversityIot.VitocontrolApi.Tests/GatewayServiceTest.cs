using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityIot.VitocontrolApi.Entities;
using UniversityIot.VitocontrolApi.Repositories;
using UniversityIot.VitocontrolApi.Services;

namespace UniversityIot.VitocontrolApi.Tests
{
    [TestFixture]
    public class GatewayServiceTest
    {
        private Mock<GatewayRepository> _gatewayRepositoryMock;
        private GatewayServices _sut;

        [SetUp]
        public void Setup()
        {
            _gatewayRepositoryMock = new Mock<GatewayRepository>();
            //_sut = new GatewayServices(_gatewayRepositoryMock.Object);
        }

        [Test]
        public void foo()
        {
            //Arrange
            var returnedBool = true;
            _gatewayRepositoryMock.Setup(s => s.CreateGateway(It.IsAny<int>())).Returns(returnedBool);

            //Act 
            int serialNumber = 1;
            var Gateway = _sut.RegisterGateway(serialNumber);

            //Assert
            Assert.AreEqual(returnedBool, serialNumber);
        }
    }
}
