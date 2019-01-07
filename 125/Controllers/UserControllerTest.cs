using BusinessLogicLayer.Interfaces;
using Common.Core;
using Ledger.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Web.Mvc;

namespace UnitTests.Controllers
{
    [TestClass]
    public class UserControllerTest
    {
        [TestMethod]
        public void Index()
        {
            var mock = new Mock<IBusinessLogic>();
            mock.Setup(a => a.Users.GetUsers()).Returns(new List<User>());

            UsersController controller = new UsersController(mock.Object);

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result.Model);
        }
    }
}
