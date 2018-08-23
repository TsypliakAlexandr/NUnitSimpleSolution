using CSharpCalculator;
using NUnit.Framework;
using System;
using System.Threading;

namespace AutoTest
{
    [TestFixture]
    [Parallelizable(ParallelScope.All)]
    class Add_test:LoggingTests
    {
        Calculator calculator = new Calculator();

        [Test, TestCaseSource("Cases")]
        public void Add(object input_1, object input_2)
        {
            //Thread.Sleep(1000); for paralelization testing
            double sumExpected = Convert.ToDouble(input_1) + Convert.ToDouble(input_2);
            double sumCalculator = calculator.Add(input_1, input_2);
            Assert.AreEqual(sumExpected, sumCalculator);

        }

        static object[] Cases =
        {
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
