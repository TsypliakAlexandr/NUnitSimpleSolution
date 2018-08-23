using CSharpCalculator;
using NUnit.Framework;
using System;


namespace AutoTest
{
    [TestFixture]
    [Parallelizable]
    class Sqrt_test : LoggingTests
    {
        Calculator calculator = new Calculator();

        [Test, TestCaseSource("Cases")]
        public void Sqrt(object input)
        {
            double resultExpected = Math.Sqrt(Convert.ToDouble(input));
            double resultCalculator = calculator.Sqrt(input);
            Assert.AreEqual(resultExpected, resultCalculator);
        }
        static object[] Cases =
        {
            new object[] { 3.1},
            new object[] { 4.0},
            new object[] { 0.0},
            new object[] { -2.0},

            new object[] {2},
            new object[] {-2},
            new object[] {"2"},
            new object[] {"2.2"},
            new object[] {"-2.2"},
            new object[] {Math.PI}
        };
    }
}
