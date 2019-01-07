using DataAccessLayer.Implementation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UtinTests.Implementation
{
    [TestClass]
    public class SubjectRepositoryTests
    {
        [TestMethod]
        public void GetSubjectsTest()
        {
            SubjectRepository repository = new SubjectRepository();

            var result = repository.GetSubjects();

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void GetSubjects()
        {
            SubjectRepository repository = new SubjectRepository();

            var result = repository.GetSubjectById(1);

            Assert.IsNotNull(result);
        }
    }
}
