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
        public void methodGenerateData1()
        {
            API.service.dsAddUser("Joris", "Loit",1);
            API.service.dsAddUser("Jack", "Sparrow",2);
            API.service.dsAddUser("Rhum", "Blanc",3);
            API.service.dsAddBook("Odyssey","Homère", 1);
            API.service.dsAddBook("Moby-Dick ", "Herman Melville",2);
            API.service.dsAddBook("Around the World in Eighty Days ", "Jules Verne",3);
        }
        public void methodGenerateData2()
        {
            API.service.dsAddUser("Joris", "Loit",1);
            API.service.dsAddUser("Jack", "Sparrow",2);
            API.service.dsAddUser("Rhum", "Blanc",3);
           

            API.service.dsAddBook("Odyssey","Homère", 1);
            API.service.dsAddBook("Moby-Dick ", "Herman Melville",2);
            API.service.dsAddBook("Around the World in Eighty Days ", "Jules Verne",3);
            API.service.dsAddBook("Odyssey","Homère", 4);
            API.service.dsAddBook("Odyssey","Homère", 5);
            API.service.dsAddBook("Odyssey","Homère", 6);
            API.service.dsAddBook("Moby-Dick ", "Herman Melville",7);
        }


        [TestMethod]
        public void Borrowing()
        {
            methodGenerateData1();
            API.service.BorrowBook("Odyssey", "Homère", "Jack", "Sparrow", 1, 2);
            Assert.IsFalse(API.service.dsGetAvailability(1));
        }

        [TestMethod]
        public void Returning()
        {
            methodGenerateData2();
            API.service.BorrowBook("Odyssey","Homère","Jack","Sparrow",4,2);
            API.service.ReturnBook("Odyssey","Homère","Jack","Sparrow",4,2);
 
            Assert.IsTrue(API.service.dsGetAvailability(4));
        }

        [TestMethod]
        public void Deleting()
        {
            API.service.dsAddUser("Joris", "Loit", 1);
            API.service.dsAddBook("Odyssey", "Homère", 1);
            API.service.dsDeleteBook(1);
        }

        [TestMethod]
        public void sameBookNameDifferentAvailability()
        {
            methodGenerateData2();
            API.service.BorrowBook("Odyssey", "Homère", "Joris", "Loit", 4, 1);
            Assert.AreNotEqual(API.service.dsGetAvailability(4),API.service.dsGetAvailability(5));
        }
    }
}