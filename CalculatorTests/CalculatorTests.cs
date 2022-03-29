using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lab1;

namespace CalculatorTests
{
    [TestClass]
    public class CalculatorTests
    {
        [TestMethod]
        public void TestAdd1()
        {
            int a = 5;
            int b = 8;
            int expected = 13;
            Calculator calculator = new Calculator();
            int c = calculator.Add(a, b);
            Assert.AreEqual(c, expected);

        }
        [TestMethod]
        public void TestAdd2()
        {
            int a = 5;
            int b = 8;
            int expected = 15;
            Calculator calculator = new Calculator();
            int c = calculator.Add(a, b);
            Assert.AreNotEqual(c, expected);

        }
        [TestMethod]
        public void TestMultiply1()
        {
            int a = 5;
            int b = 8;
            int expected = 40;
            Calculator calculator = new Calculator();
            int c = calculator.Multiply(a, b);
            Assert.AreEqual(c, expected);

        }
        [TestMethod]
        public void TestMultiply2()
        {
            int a = 5;
            int b = 8;
            int expected = 20;
            Calculator calculator = new Calculator();
            int c = calculator.Multiply(a, b);
            Assert.AreNotEqual(c, expected);

        }
    }
}