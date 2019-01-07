using BusinessLogicLayer.Interfaces;
using Common.Core;
using Ledger.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Web.Mvc;

namespace UtinTests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Index()
        {
            var mock = new Mock<IBusinessLogic>();
            mock.Setup(a => a.Subjects.GetSubjects()).Returns(new List<Subject>());

            HomeController controller = new HomeController(mock.Object);

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result.Model);
        }
    }
}
