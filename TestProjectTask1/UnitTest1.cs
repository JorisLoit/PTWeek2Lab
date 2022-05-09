using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjectTask1.Logic;
using ProjectTask1.Data;

namespace TestProjectTask1
{
    [TestClass]
    public class UnitTest1
    {
        BusinessLogicApi? API;

        [TestInitialize]
        public void TestInitialize()
        {
            API = new BusinessLogicApi(new DataAPI());
        }

        [TestMethod]
        public void Borrowing()
        {
            API.service.dsAddUser("Joris", "Loit", 1);
            API.service.dsAddBook("Odyssey","Homère", 1);
            API.service.BorrowBook("Odyssey", "Homère", "Joris", "Loit", 1, 1);
            Assert.IsFalse(API.service.dsGetAvailability(1));
        }

        [TestMethod]
        public void Returning()
        {
            API.service.dsAddUser("Joris", "Loit", 1);
            API.service.dsAddBook("Odyssey", "Homère", 1);
            API.service.BorrowBook("Odyssey", "Homère", "Joris", "Loit", 1, 1);
            API.service.ReturnBook("Homère", "Odyssey", "Joris", "Loit", 1, 1);
            Assert.IsTrue(API.service.dsGetAvailability(1));
        }

        [TestMethod]
        public void Deleting()
        {
            API.service.dsAddUser("Joris", "Loit", 1);
            API.service.dsAddBook("Odyssey", "Homère", 1);
            API.service.dsDeleteBook(1);
        }


    }
}