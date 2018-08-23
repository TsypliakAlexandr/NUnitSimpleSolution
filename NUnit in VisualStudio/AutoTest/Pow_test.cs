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
    class Pow_test : LoggingTests
    {
        Calculator calculator = new Calculator();

        [Test, TestCaseSource("Cases")]
        public void Pow(object input_1, object input_2)
        {
            double resultExpected = Math.Pow(Convert.ToDouble(input_1), Convert.ToDouble(input_2));
            double resultCalculator = calculator.Pow(input_1, input_2);
            Assert.AreEqual(resultExpected, resultCalculator);
        }
        static object[] Cases =
        {
            new object[] { 3.1, 2.0},
            new object[] { 4.0, 0.0},
            new object[] { 0.0, 1.0},
            new object[] { -2.0, 2.0},
            new object[] { -2.0, 3.0},

            new object[] {2, 3},
            new object[] {-2, 0},
            new object[] {"2", "2"},
            new object[] {"2.2", "2.0"},
            new object[] {"-2.2", "-2"},
            new object[] {0, 0}
        };
    }
}
