using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interface.Entities;
using BLL.Interface.Interfaces;
using BLL.ServiceImplementation;
using Moq;
using NUnit.Framework;

namespace BLL.Tests
{
    public class AccountServiceTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void OpenAccountTest()
        {
            // Arrange
            var service = new Mock<IAccountService>();
            var creator = new Mock<IAccountNumberCreateService>();

            // Act
            service.Object.OpenAccount("Base acc owner 1", AccountType.Base, creator.Object);

            // Assert
            //Assert.That(service.Object.GetAllAccounts(), Is.Unique);
            service.Setup(foo => foo.GetAllAccounts()[0].Name == "Base acc owner 1");
        }
    }
}
