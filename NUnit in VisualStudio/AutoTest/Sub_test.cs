using CSharpCalculator;
using log4net;
using log4net.Config;
using NUnit.Framework;
using System;
using System.IO;

namespace AutoTest
{
    [TestFixture]
    [Parallelizable]
    class Sub_test : LoggingTests
    {
        Calculator calculator = new Calculator();

        [Test, TestCaseSource("Cases")]
        public void Sub(object input_1, object input_2)
        {
            double subExpected = Convert.ToDouble(input_1) - Convert.ToDouble(input_2);
            double subCalculator = calculator.Add(input_1, input_2);
            Assert.AreEqual(subExpected, subCalculator);

        }

        static object[] Cases =
        {
            new object[] {2.0, 1.0},
            new object[] {1.0, 2.0},
            new object[] {1.2, 2.0},
            new object[] {1.0, -2.0},
            new object[] {1.2, -2.0},
            new object[] {1.0, 0.0},

            new object[] {"1.0", "2.0"},
            new object[] {"1.2", "2.0"},
            new object[] {"1.0", "-2.0"},
            new object[] {"1.2", "-2.0"},
            new object[] {"1.0", "0.0"},

            new object[] {1, 2},
            new object[] {1, -2},

            new object[] {"1", "2"},
            new object[] {"1", "-2"}
        };
    }
}
