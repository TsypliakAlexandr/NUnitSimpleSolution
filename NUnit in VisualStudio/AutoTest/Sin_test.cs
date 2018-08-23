using NUnit.Framework;
using OpenQA.Selenium;
using System;
using CSharpCalculator;
using log4net;
using log4net.Config;
using NUnit.Framework.Internal;

namespace AutoTest
{
    [TestFixture]
    [Parallelizable]
    class Sin_test : LoggingTests
    {
        Calculator calculator = new Calculator();

        [Test, TestCaseSource("Cases")]
        public void Sin(object input)
        {
            double resultExpected = Math.Sin(Convert.ToDouble(input));
            double resultCalculator = calculator.Sin(input);
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
            new object[] {Math.PI/2}
        };
    }
}
