using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Task2.Presentation.Model;
using Task2.Presentation.ViewModel;

namespace TestTask2
{
    [TestClass]
    public class ViewModelTest
    {

        MainWindowViewModel vwm1 = new MainWindowViewModel();
        MainWindowViewModel vwm2 = new MainWindowViewModel();

        [TestInitialize]
        public void init()
        {
            vwm1.mainModel.myLibrary.AddUser("Joris", "Loit");
            vwm2.mainModel.myLibrary.AddUser("Joris", "Loit");

        }


        [TestMethod]
        public void TestMethod1()
        {
          

            MyLibrary lib = vwm1.mainModel.myLibrary;
          

            int initial = lib.STATES.Count;
            lib.AddState(new State(new Catalog("book1", "book1")));
            Assert.IsTrue(lib.STATES.Count == initial+1);
            

        }
        [TestMethod]
        public void Test2()
        {
            MyLibrary lib = vwm1.mainModel.myLibrary;

            lib.Borrow("book1", "book1", new User("Joris", "Loit"));
            Assert.IsTrue(lib.isAvailble("book1", "book1") == false);
            lib.Return("book1", "book1", new User("Joris", "Loit"));
         

        }

    } 
}
