using DataAccessLayer.Implementation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UtinTests.Implementation
{
    [TestClass]
    public class RegisterRepositoryTest
    {
        [TestMethod]
        public void CheckLoginForRegister()
        {
            RegisterRepository repository = new RegisterRepository();

            var result = repository.CheckLoginForRegister("Admin");

            Assert.AreEqual(false, result);
        }
    }
}
