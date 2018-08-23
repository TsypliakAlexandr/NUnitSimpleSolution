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
    class Divide_test : LoggingTests
    {
        Calculator calculator = new Calculator();

        [Test, TestCaseSource("Cases")]
        public void Divide(double n, double d)
        {
            double resultCalculator = calculator.Divide(n, d);
            double resultExpected = n / d;
            Assert.AreEqual(resultExpected, resultCalculator);
        }
        static object[] Cases =
        {
            new object[] { 2.0, 3.1},
            new object[] { 3.1, 2.0},
            new object[] { 4.0, 2.0},
            new object[] { 0.0, 0.0},
            new object[] { -2.0, 3.0},
            new object[] { 2.0, -3.0},
            new object[] { 2.2, -3},
            new object[] { 3.1, 0.0},

            new object[] { 2, 3},
            new object[] { 2, -3},
            new object[] { "2", "3"},
            new object[] { "2.2", "3.0"},
            new object[] { "-2.2", "3.0"}
        };
    }
}
