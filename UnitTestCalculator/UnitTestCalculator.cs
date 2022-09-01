using Microsoft.VisualStudio.TestTools.UnitTesting;
using Calculator;
namespace UnitTestCalculator
{
    [TestClass]
    public class UnitTestCalculator
    {
        [TestMethod]
        public void TestAdditionCalculation()
        {
            //Test that expect to pass
            decimal value1 = 15;
            decimal value2 = 6;

            decimal result = Calculator.Calculator.Calculate(value1, value2, Operator.Addition);

            Assert.AreEqual(result, 21);
        }

        [TestMethod]
        public void TestSubtractionCalculation()
        {
            //Test that expect to pass
            decimal value1 = 15;
            decimal value2 = 6;

            decimal result = Calculator.Calculator.Calculate(value1, value2, Operator.Subtraction);

            Assert.AreEqual(result, 9);
        }

        [TestMethod]
        public void TestMultiplicationCalculation()
        {
            //Test that expect to pass
            decimal value1 = 5;
            decimal value2 = 6;

            decimal result = Calculator.Calculator.Calculate(value1, value2, Operator.Multiplication);

            Assert.AreEqual(result, 30);
        }


        [TestMethod]
        public void TestDivisionCalculation()
        {
            //Test that expect to pass
            decimal value1 = 15;
            decimal value2 = 5;

            decimal result = Calculator.Calculator.Calculate(value1, value2, Operator.Division);

            Assert.AreEqual(result, 3);
        }
    }
}
