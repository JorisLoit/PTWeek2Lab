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
        [TestMethod]
        public void TestMethod1()
        {
           

            MyLibrary lib = vwm1.mainModel.myLibrary;

            int initial = lib.STATES.Count;
            lib.AddState(new State(new Catalog("Book1", "Book1")));
            Assert.IsTrue(lib.STATES.Count == initial+1);
         



        }
        [TestMethod]
        public void Test2()
        {
            MyLibrary lib = vwm1.mainModel.myLibrary;

            lib.Borrow("Book1", "Book1", new User("Joris", "Loit"));
            Assert.IsTrue(lib.isAvailble("Book1", "Book1") == false);
            lib.Return("Book1", "Book1", new User("Joris", "Loit"));
         

        }

    } 
}
