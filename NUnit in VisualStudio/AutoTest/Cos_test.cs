using NUnit.Framework;
using OpenQA.Selenium;
using System;
using CSharpCalculator;
using log4net;
using log4net.Config;
namespace AutoTest
{
    [TestFixture]
    [Parallelizable]
    class Cos_test : LoggingTests
    {
        Calculator calculator = new Calculator();

        [Test, TestCaseSource("Cases")]
        public void Cos(object input)
        {
            double resultExpected = Math.Cos(Convert.ToDouble(input));
            double resultCalculator = calculator.Cos(input);
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
